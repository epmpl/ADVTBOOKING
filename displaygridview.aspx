<%@ Page Language="C#" AutoEventWireup="true" CodeFile="displaygridview.aspx.cs" Inherits="displaygridview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <table id="OuterTable" border="0" width="100%" cellpadding="0" cellspacing="0" align="center">        
       
        <tr>
            <td align="center" colspan="5">
                <asp:Label ID="lblmsg" runat="server" CssClass="TextField" Font-Bold="true" Font-Size="Large"></asp:Label>
            </td>
          
        </tr><tr></tr>
        <tr>
        <td style="width:46px"></td>
            <td align="left" >
                <asp:Label ID="lblfromdate" runat="server" CssClass="TextField"></asp:Label>&nbsp;&nbsp;&nbsp;
                <asp:Label ID="txtfromdate" runat="server" CssClass="TextField"></asp:Label>&nbsp;&nbsp;                       
               
            </td>
            <td align="right">
             <asp:Label ID="lbltodate" runat="server" CssClass="TextField"></asp:Label>&nbsp;&nbsp;            
                <asp:Label ID="txttodate" runat="server" CssClass="TextField"></asp:Label>
            </td>
            <td style="width:50px"></td>
        </tr>
          
    </table>
    <div style="OVERFLOW: auto">
    <br />
										<table id="Table1" align="center" width="100%">
											<tr>
												<td align="center" style="width:100%">
                                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Font-Size="Smaller" BorderWidth="0px" >
                                                        <Columns>
                                                            
                                                            <asp:BoundField DataField="cio_booking_id" HeaderText="Booking Id" />
                                                            <asp:BoundField DataField="agency_name" HeaderText="Agency" />
                                                            <asp:BoundField DataField="creation_datetime" HeaderText="Booking Date" />
                                                            <asp:BoundField DataField="client_name" HeaderText="Client" />
                                                            <asp:BoundField DataField="uom_name" HeaderText="UOM" />
                                                            <asp:BoundField DataField ="cat_name" HeaderText=" Category" />
                                                            <asp:BoundField DataField ="subcat_name" HeaderText=" Sub Category" />
                                                            <asp:BoundField DataField ="col_name" HeaderText=" Color" />
                                                            <asp:BoundField DataField ="Package_code" HeaderText=" PackageCode" />
                                                            <asp:BoundField DataField ="card_rate" HeaderText="Card Rate" />
                                                            <asp:BoundField DataField ="gross_amount" HeaderText="Amount" />
                                                            <asp:BoundField DataField ="total_area" HeaderText=" Tatal Area" />
                                                            <asp:BoundField DataField ="insert_date" HeaderText=" Schedule Date" />
                                                          
                                                            
                                                        </Columns>
                                                    </asp:GridView>
                                                    <asp:Label ID="lblerrormsg" runat="server" ></asp:Label>
											    </td>
											</tr>
										
										</table>
									</div>
		
    
    
    
    
    <div></div>
    </form>
</body>
</html>
