<%@ Page Language="C#" AutoEventWireup="true" CodeFile="orderwise_last.aspx.cs" Inherits="orderwise_last" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Order_Wise(last)</title>
    <link href="css/main.css" type="text/css" rel="stylesheet" />
    <link href="css/booking.css" type="text/css" rel="stylesheet" />
    <link href="css/report.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" language="javascript" src="javascript/popupcalender.js"></script>

    <script type="text/javascript" language="javascript" src="javascript/entertotab.js"></script>

    <script language="javascript" src="javascript/orderwise_last.js" type="text/javascript"></script>

    <%--	  				  <script language="javascript">

//window.onbeforeunload = function() //event.keyCode
//{
//      fnUnloadHandler();//event.keyCode
//      //alert("Unload event.. Do something to invalidate users session..");
//}
</script>  --%>
    <style type="text/css">
        .hiddencol
        {
            display: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <tr>
        <td>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </td>
    </tr>
    <tr style="visibility: hidden">
        <td width="100%" bordercolor="#1">
            <img src="images/top.jpg" width="100%" align="center" border="0" />
        </td>
    </tr>
    <table cellpadding="0" cellspacing="0" width="100%" style="vertical-align: top;">
        <tr>
            <td align="center">
                <div id="div3" runat="server" style="display: block; overflow: auto; vertical-align: top;
                    width: 850px; height: 450px; top: 100px;">
                    <table id="Table2" align="center">
                        <tr>
                            <td align="center">
                                <asp:RadioButton ID="rboriginal" GroupName="1" Text="Original" runat="server" />
                                <asp:RadioButton ID="rbduplicate" GroupName="1" runat="server" Text="Duplicate" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="height: 205px">
                                <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                                    <ContentTemplate>
                                        <asp:DataGrid ID="DataGrid3" runat="server" CssClass="dtGrid" Width="770px" AutoGenerateColumns="False"
                                            OnItemDataBound="DataGrid3_ItemDataBound">
                                            <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
                                            <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12"
                                                BackColor="#7DAAE3"></HeaderStyle>
                                            <Columns>
                                                <%--<asp:TemplateColumn HeaderText="Audit"></asp:TemplateColumn>--%>
                                                <asp:BoundColumn DataField="Cio_Booking_Id" HeaderText="Cio_Booking_Id" SortExpression="cio_booking_id">
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                        Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn HeaderText="Invoice_No" DataField="BILL_NO">
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                        Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="Commission" HeaderText="Commission">
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                        Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="Agency" HeaderText="Agency" SortExpression="Agency">
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                        Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="client" HeaderText="Client" SortExpression="Client">
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                        Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
                                                </asp:BoundColumn>
                                                <%--     <asp:BoundColumn  HeaderText="RoNo" DataField="ro_no_v" >
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>--%>
                                                <asp:BoundColumn HeaderText="No_of_insertion" DataField="NoOfAds">
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                        Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn HeaderText="Total_Count" DataField="TotalCount">
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                        Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn HeaderText="Total_Audited" DataField="AuditCount">
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                        Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn HeaderText="Print Count" DataField="PrintCount">
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                        Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
                                                </asp:BoundColumn>
                                                <%-- <asp:BoundColumn  HeaderText="Booking_dt" DataField="bkdate" >
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
        
          
          
          
          
              <asp:BoundColumn DataField="checkstatus" HeaderText="Bill_status" SortExpression="Client">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
          
          
          
                 <asp:BoundColumn  HeaderText="Audited"  Visible ="true">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
          
            --%>
                                                <asp:TemplateColumn>
                                                    <HeaderTemplate>
                                                        <input id="Checkbox4" type="checkbox" name="Checkbox4" runat="server" onclick="SelectHILAST('DataGrid3',this,'Checkbox4');" />
                                                    </HeaderTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center" Width="20px" VerticalAlign="Middle"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="CheckBox1" CssClass="TextField1" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                            </Columns>
                                        </asp:DataGrid>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
            <table style="width: 880px;">
                <tr align="right">
                    <td>
                        <table>
                            <tr>
                                <td align="right" colspan="3">
                                    <asp:Button ID="Button1" Style="width: 70px; height: 30px; font-size: 11px; font-family: arial;
                                        margin-right: 0px;" ForeColor="White" runat="server" BackColor="#7DAAE3" Text="BillSummary"
                                        CssClass="buttonnew" />
                                </td>
                                <td width="200px">
                                </td>
                                <td width="200px">
                                </td>
                                <td align="center">
                                    <td align="right">
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox runat="server" ID="txtdate"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td>
                                        <img src='Images/cal1.gif' onclick='popUpCalendar(this, form1.txtdate, "mm/dd/yyyy")'
                                            onfocus="abc();" height="14" width="14" />
                                    </td>
                                    <td align="right">
                                        <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btnprv" Style="width: 70px; height: 30px; font-size: 11px; font-family: arial;
                                                    margin-right: 0px;" ForeColor="White" runat="server" BackColor="#7DAAE3" Text="BillPreview"
                                                    CssClass="buttonnew" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                    <td align="right">
                                        <asp:UpdatePanel ID="UpdatePane29" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btngenrate" Style="width: 70px; height: 30px; font-size: 11px; font-family: arial;
                                                    margin-right: 0px;" ForeColor="White" runat="server" Text="BillGenerate" CssClass="buttonnew"
                                                    BackColor="#7DAAE3" Width="93px" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </td>
                            </tr>
                            <tr>
                                <td width="400px">
                                </td>
                                <td width="400px">
                                </td>
                                <td align="right" colspan="2">
                                    <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnprint" Style="width: 70px; height: 30px; font-size: 11px; font-family: arial;
                                                margin-right: 0px;" ForeColor="White" runat="server" Text="BillPrint" CssClass="buttonnew"
                                                BackColor="#7DAAE3" /></ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td align="right">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btn_mail" Style="width: 70px; height: 30px; font-size: 11px; font-family: arial;
                                                margin-right: 0px;" ForeColor="White" runat="server" Text="BillMail" CssClass="buttonnew"
                                                BackColor="#7DAAE3" /></ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td align="right">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btn_printletter" Style="width: 70px; height: 30px; font-size: 11px;
                                                font-family: arial; margin-right: 0px;" ForeColor="White" runat="server" Text="BillLetter"
                                                CssClass="buttonnew" BackColor="#7DAAE3" /></ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                    </td>
                </tr>
            </table>
        </tr>
    </table>
    <table>
        <input id="hiddendateformat" type="hidden" runat="server" />
        <input id="hiddendateformat1" type="hidden" runat="server" />
        <input id="hiddenascdesc" type="hidden" runat="server" />
        <input id="hiddencioid" type="hidden" runat="server" />
        <td>
            <input id="hiddenolddate" type="hidden" name="hiddenolddate" runat="server" />
        </td>
        <input id="hiddencompcode" type="hidden" size="1" name="hiddencompcode" runat="server" />
        <input id="hidden1" type="hidden" size="1" name="hiddencompcode" runat="server" />
        <input id="hiddenradio" type="hidden" size="1" name="hiddencompcode" runat="server" />
        <input id="hiddenrowcount" type="hidden" size="1" runat="server" />
        <asp:UpdatePanel ID="updatehidden" runat="server">
            <ContentTemplate>
                <input id="hiddenbooking" type="hidden" runat="server" />
                <input id="hiddeninsertion" type="hidden" runat="server" />
                <input id="hiddenfromdate" type="hidden" runat="server" />
                <input id="hiddendateto" type="hidden" runat="server" />
                <input id="hiddenclient" type="hidden" runat="server" />
                <input id="hiddencheck" type="hidden" runat="server" />
                <input id="hiddenbillstatus" type="hidden" runat="server" />
                <input id="hiddendisplaybill" type="hidden" runat="server" />
                <input id="hiddenclsbill" type="hidden" runat="server" />
                <input id="hiddenclsbillnew" type="hidden" runat="server" />
                <input id="hiddenadtype" type="hidden" runat="server" />
                <input id="gaudtformat" type="hidden" runat="server" />
                <input id="gautodate" type="hidden" runat="server" />
                <input id="gaufromdt" type="hidden" runat="server" />
                <input id="gaupub" type="hidden" runat="server" />
                <input id="gaubkcen" type="hidden" runat="server" />
                <input id="gaurev" type="hidden" runat="server" />
                <input id="gauagtype" type="hidden" runat="server" />
                <input id="gaupckg" type="hidden" runat="server" />
                <input id="gauadtyp" type="hidden" runat="server" />
                <input id="gauag" type="hidden" runat="server" />
                <input id="gauclient" type="hidden" runat="server" />
                <input id="gaubillstate" type="hidden" runat="server" />
                <input id="gaurtaudit" type="hidden" runat="server" />
                <input id="gaublmod" type="hidden" runat="server" />
                <input id="gaublcycle" type="hidden" runat="server" />
                <input id="chk_idstatus" type="hidden" runat="server" />
                <input id="HDN_server_date" type="hidden" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </table>
    </form>
</body>
</html>
