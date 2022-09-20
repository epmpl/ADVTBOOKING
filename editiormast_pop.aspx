<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editiormast_pop.aspx.cs" Inherits="editiormast_pop" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Editor MAster PopUp</title>
    <link href="css/main.css" type="text/css" rel="stylesheet"/>
		<link href="css/booking.css" type="text/css" rel="stylesheet"/>
		<link href="css/report.css" type="text/css" rel="stylesheet"/>
		<script type="text/javascript"  language="javascript" src="javascript/popupcalender.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/EditorMaster.js"></script>
		<script language="javascript" type="text/javascript">
        
        function chknumber()
        {
        //alert(event.keyCode);
        if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 127) || (event.keyCode == 8) ||(event.keyCode == 9) || (event.keyCode == 43) || (event.keyCode == 46)) 
        {
        //if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9))
        
        
       
        //
        return true;
        }
        else
        {
        return false;
        }

        }

            </script>
    <style type="text/css">
        .style2
        {
            width: 30%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
      <table border="1" cellpadding="0" cellspacing="0" style="border-color:Black;margin-left:65px;margin-top: 35px;">
        <tr>
           <td>
              <table cellpadding="0" cellspacing="0" style="height: 196px;">
                 <tr>
                    <td>
                       <table id="Table4" align="center" bgcolor="#7daae3" border="0" cellpadding="0" cellspacing="0" width="633">
                         <tr>
                           <td align="center" class="btnlink" style="height: 18px">
                            Circulation Detail
                           </td>
                         </tr>
                       </table>
                       <asp:ScriptManager ID="ScriptManager1" runat="server">
                       </asp:ScriptManager>
                     </td>
                   </tr>
                 <tr>
                     <td align="center">
                       <table width="50%" cellpadding="0" cellspacing="0" style="padding-left: 47px;">
                          <tr>
                            <td align="left" style="width:35%">
                              <asp:Label ID="lblcrcu" runat="server" CssClass="TextField" ></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtcrcu" runat="server" CssClass="numerictext" onkeypress="return chknumber();"></asp:TextBox>
                            </td>
                            </tr>
                        </table>
                     </td>
                 </tr>
                 <tr>
                     <td align="center">
                       <table width="50%" cellpadding="0" cellspacing="0" style="padding-left: 47px;">
                          <tr>      
                            <td align="left" style="width:35%">
                              <asp:Label ID="lblrder" runat="server" CssClass="TextField" ></asp:Label>
                            </td>
                            <td align="left">
                                 <asp:TextBox ID="txtno" runat="server" CssClass="numerictext" onkeypress="return chknumber();"></asp:TextBox>
                            </td>                         
                         </tr>
                     </table>
                     </td>
                   </tr>
                 <tr>
                     <td align="center">
                       <table width="50%" cellpadding="0" cellspacing="0" style="padding-left: 47px;">
                          <tr>
                            <td align="left" style="width:35%">
                              <asp:Label ID="lblstate" runat="server" CssClass="TextField" ></asp:Label>
                            </td>
                            <td align="left">
                                   <asp:DropDownList id="drpState" runat="server" CssClass="dropdown" ></asp:DropDownList>
                             </td>
                            </tr>
                     </table>
                     </td>
                   </tr>
                    <tr>
                     <td align="center">
                       <table width="50%" cellpadding="0" cellspacing="0" style="padding-left: 47px;">
                          <tr>        
                            <td align="left" style="width:35%">
                              <asp:Label ID="lbldstrct" runat="server" CssClass="TextField" ></asp:Label>
                            </td>
                            <td align="left">
                                        <asp:DropDownList id="drpdistrct" runat="server" CssClass="dropdown">
                                        <asp:ListItem Value="0">---Select District---</asp:ListItem>
                                        </asp:DropDownList>
                            </td>                         
                         </tr>
                     </table>
                     </td>
                   </tr>
                   <tr>
                     <td align="center">
                       <table width="50%" cellpadding="0" cellspacing="0" style="padding-left: 47px;">
                          <tr>        
                            <td align="left" style="width:35%">
                              <asp:Label ID="lblcity" runat="server" CssClass="TextField" ></asp:Label>
                            </td>
                            <td align="left">
                                        <asp:DropDownList id="drpCity" runat="server" CssClass="dropdown" >
                                        </asp:DropDownList>
                            </td>                         
                         </tr>
                     </table>
                     </td>
                   </tr>
                     <tr>
                        <td align="center" >
                        <asp:Button ID="btnsubmit" runat="server" CssClass="buttonpop"></asp:Button> 
                        <asp:Button ID="btnupdate" runat="server" CssClass="buttonpop" ></asp:Button>
                        <asp:Button ID="btnclose" runat="server" CssClass="buttonpop" ></asp:Button>
                        </td>
                     </tr> 
                </table>
              </td> 
           </tr>
        </table>
        
        <table cellpadding="0" cellspacing="0" style="border-color:Black;margin-left:65px;margin-top: 35px;">
        <tr>
        <td>
        <div id="tdgrid" style="width:640px; height:100px;overflow:auto;">
        <asp:datagrid  ID="contactgrid" Width="635px" runat="server" AutoGenerateColumns="False" AllowSorting="True" CssClass="dtGrid" OnItemDataBound="DataGrid_ItemDataBound">
        <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
                <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3" />
                    <Columns>
                    <asp:TemplateColumn>
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                    </asp:TemplateColumn>
                    <asp:BoundColumn HeaderText="Circulation" DataField="CIRC_NO" SortExpression="CIRC_NO" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Reader Ship" DataField="READER_NO" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="State" DataField="STATE" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="District" DataField="DISTRICT">
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="City" DataField="CITY">
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Seq.No" DataField="SEQ_NO" Visible="false">
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Edition Code" DataField="EDITIONCODE" Visible="false">
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        </Columns>
                        </asp:datagrid>
         </div>
        </td>
        </tr>
        </table>
        
        <input id="edicod" type="hidden" name="editioncode" runat="server"/>
        <input id="cityname" type="hidden" name="cityname" runat="server"/>
        <input id="hiddencompcode" type="hidden" size="5" name="hiddenregion" runat="server" />
        <input id="hiddenuserid" type="hidden" size="1" name="hiddenregion" runat="server"/>
        <input id="hidseq" type="hidden" size="1" runat="server"/>
        <input id="hidnstate" type="hidden" size="1" runat="server"/>
        <input id="hidndist" type="hidden" size="1" runat="server"/>
        <input id="hidncity" type="hidden" size="1" runat="server"/>
        </form>
</body>
</html>
