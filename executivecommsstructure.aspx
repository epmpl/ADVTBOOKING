<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false"  CodeFile="executivecommsstructure.aspx.cs" Inherits="executivecommsstructure" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Executive Commission Structure</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
    <meta content="C#" name="CODE_LANGUAGE" />
    <meta content="JavaScript" name="vs_defaultClientScript" />
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />

    <script language="javascript" type="text/javascript" src="javascript/AdvertisementMaster.js"></script>

    <script language="javascript" type="text/javascript" src="javascript/Validations.js"></script>

    <script language="javascript" type="text/javascript" src="javascript/popupcalender.js"></script>

<script language="javascript" type="text/javascript"src="javascript/entertotab.js"></script>

    <script language="javascript" type="text/javascript" src="javascript/datevalidation.js"></script>

    <link href="css/main.css" type="text/css" rel="stylesheet" />

    <script language="javascript" type="text/javascript">
	function notchar2(event)
    {
      var browser=navigator.appName;

   if(browser!="Microsoft Internet Explorer")
    { 
            if((event.which>=46 && event.which<=57)||(event.which==127)||(event.which==8)||(event.which==9))
            {
            return true;
            }
            else
            {
            return false;
            }
      }
      else
      {
            if((event.keyCode>=46 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9))
            {
            return true;
            }
            else
            {
            return false;
            }
      }
      
     }
    </script>
   <script language="javascript" type="text/javascript">
	var message = "function disabled"; 
	function rtclickcheck(keyp){ if (navigator.appName == "Netscape" && keyp.which == 3){ 	alert(message); return false; } 
	if (navigator.appVersion.indexOf("MSIE") != -1 && event.button == 2) { 	return false; } } 
	document.onmousedown = rtclickcheck;
</script>

</head>
<body onload="loadXML('xml/errorMessage.xml')" onkeydown="javascript:return tabvalue(event);">
    <form id="Form1"   runat="server">
    
    <asp:ScriptManager ID="s1" runat="server"></asp:ScriptManager>
    <table id="Table4" bordercolor="#000000" cellspacing="0" cellpadding="0" width="632"
        align="center" border="1" runat="server">
        <tbody>
            <tr valign="middle">
                <td style="width: 636px">
                    <table id="Table3" cellspacing="0" cellpadding="0" width="633" align="center" bgcolor="#7daae3"
                        border="0">
                        <tr>
                            <td class="btnlink" align="center">
                                Executive Comm. Structure
                            </td>
                        </tr>
                    </table>
                    <table id="table1">
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <table style="width: 600px; height: 80px">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblfromtgt" runat="server" CssClass="TextField"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtfrom" runat="server" style="text-align:right" CssClass="btext1" onkeypress="return notchar2(event);"
                                                onpaste="return false;" MaxLength="3"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblteam" runat="server" CssClass="TextField"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drpteam" runat="server" CssClass="dropdown">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 16px">
                                            <asp:Label ID="lbltotgt" runat="server" CssClass="TextField"></asp:Label>
                                        </td>
                                        <td style="height: 16px">
                                            <asp:TextBox ID="txtto" runat="server" style="text-align:right" CssClass="btext1" onpaste="return false;"
                                                onkeypress="return notchar2(event);" MaxLength="3"></asp:TextBox>
                                        </td>
                                        <%--<td>
                                            <asp:Label ID="lblcategory" runat="server" CssClass="TextField"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drpcat" runat="server" CssClass="dropdown">
                                            </asp:DropDownList>
                                        </td>--%>
                                        <td>
                                            <asp:Label ID="lbladpub" runat="server" CssClass="TextField"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drpadpub" runat="server" CssClass="dropdown">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 16px">
                                            <asp:Label ID="lblcusttype" runat="server" CssClass="TextField"></asp:Label>
                                        </td>
                                        <td style="height: 16px">
                                            <asp:DropDownList ID="drpcusttype" runat="server" CssClass="dropdown">
                                            </asp:DropDownList>
                                        </td>
                                        <%--<td>
                                            <asp:Label ID="lbladpub" runat="server" CssClass="TextField"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drpadpub" runat="server" CssClass="dropdown">
                                            </asp:DropDownList>
                                        </td>--%>
                                        <td>
                                            <asp:Label ID="lblcategory" runat="server" CssClass="TextField"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="drpcat" runat="server" CssClass="dropdown">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 16px">
                                            <asp:Label ID="lblpubtype" runat="server" CssClass="TextField"></asp:Label>
                                        </td>
                                        <td style="height: 16px">
                                            <asp:DropDownList ID="drppubtype" runat="server" CssClass="dropdown">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="height: 16px">
                                            <asp:Label ID="lblpublication" runat="server" CssClass="TextField"></asp:Label>
                                        </td>
                                        <td style="height: 16px">
                                            <asp:ListBox ID="lstpublication" runat="server" CssClass="btext1" Height="50px" Width="200px"
                                                onpaste="return false;" MaxLength="10" SelectionMode="Multiple"></asp:ListBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td align="right">
                                            <asp:Button ID="btnSave" runat="server" CssClass="button1" OnClick="btnSubmit_Click">
                                            </asp:Button><asp:Button ID="btnclear" runat="server" CssClass="button1"></asp:Button>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <div id="Divgrid1" style="overflow: auto" runat="server">
                            <table id="Table2" align="center">
                                <tr>
                                    <td align="center">
                                        <asp:DataGrid ID="DataGrid1" runat="server" CssClass="dtGrid" AllowSorting="False"
                                            AutoGenerateColumns="False"  Width="592px" OnItemDataBound="DataGrid1_ItemDataBound">
                                            <SelectedItemStyle BackColor="#046791"></SelectedItemStyle>
                                            <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd"
                                                BackColor="#7DAAE3"></HeaderStyle>
                                            <Columns>
                                                <asp:TemplateColumn>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="CheckBox1" CssClass="textfield1" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn Visible="False" DataField="COMM_TARGET_ID" ReadOnly="True" SortExpression="COMM_TARGET_ID"
                                                    HeaderText="Elno.">
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="COMM_TARGET_ID" Visible="false"  SortExpression="COMM_TARGET_ID" HeaderText="Targetid">
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="TEAM_CODE" SortExpression="TEAM_CODE" HeaderText="Team">
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="FROM_TGT" SortExpression="FROM_TGT" HeaderText="From Target">
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="TO_TGT" SortExpression="TO_TGT" HeaderText="To Target">
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="ADCTG_CODE" HeaderText="Category">
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="CUST_TYPE" SortExpression="CUST_TYPE" HeaderText="Cust Type">
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="AD_TYPE" SortExpression="AD_TYPE" HeaderText="Ad Type">
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="PUB_TYPE" SortExpression="PUB_TYPE" HeaderText="Pub Type">
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="PUBL_CODE" SortExpression="PUBL_CODE" HeaderText="Publication">
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundColumn>
                                                <%--<asp:TemplateColumn Visible="False" HeaderText="Update">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:TemplateColumn>	--%>
                                                <asp:TemplateColumn Visible="False" HeaderText="Update">
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn Visible="False" HeaderText="Delete">
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateColumn>
                                            </Columns>
                                            <PagerStyle HorizontalAlign="Center"></PagerStyle>
                                        </asp:DataGrid>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="Divgrid2" style="overflow: auto" runat="server">
                            <table id="Table5" align="center">
                                <tr>
                                    <td align="center">
                                        <asp:DataGrid ID="DataGrid2" runat="server" CssClass="dtGrid" AllowSorting="false"
                                            AutoGenerateColumns="False"  Width="600px" 
                                            onitemdatabound="DataGrid2_ItemDataBound">
                                            <SelectedItemStyle BackColor="#046791"></SelectedItemStyle>
                                            <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd"
                                                BackColor="#7DAAE3"></HeaderStyle>
                                               
                                            <Columns>
                                                <asp:TemplateColumn>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="CheckBox1" CssClass="textfield1" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                
                                               <%--<asp:TemplateColumn Visible="false" SortExpression="COMM_TARGET_ID" HeaderText="Targetid">
                                                     <ItemTemplate>
                                                         <%# Container.DataSetIndex + 1 %>--%>
                                                     <%--</ItemTemplate>
                                               </asp:TemplateColumn>--%>
                                                <%--<asp:BoundColumn DataField="COMM_TARGET_ID" SortExpression="COMM_TARGET_ID" HeaderText="Targetid">
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundColumn>--%>
                                               
                                                 <asp:BoundColumn Visible="False" DataField="ENLN" ReadOnly="True" SortExpression="ENLN"
                                                    HeaderText="Elno.">
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="TEAM" SortExpression="TEAM" HeaderText="Team">
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="FROM_TGT" SortExpression="FROM_TGT" HeaderText="From Target">
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="TO_TGT" SortExpression="TO_TGT" HeaderText="To Target">
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="CATEGORY" HeaderText="Category">
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="CUST_TYPE" SortExpression="CUST_TYPE" HeaderText="Cust Type">
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="AD_TYPE" SortExpression="AD_TYPE" HeaderText="Ad Type">
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="PUB_TYPE" SortExpression="PUB_TYPE" HeaderText="Pub Type">
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="PUBLICATION" SortExpression="PUBLICATION" HeaderText="Publication">
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:BoundColumn>
                                                <asp:TemplateColumn Visible="False" HeaderText="Update">
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn Visible="False" HeaderText="Delete">
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateColumn>
                                            </Columns>
                                            <PagerStyle HorizontalAlign="Center"></PagerStyle>
                                        </asp:DataGrid>
                                    </td>
                                </tr>
                            </table>
                        </div>
                </td>
            </tr>
            <tr>
                <td align="center">
                </td>
                <td style="display: none">
                    <asp:TextBox ID="ttformdate" runat="server"></asp:TextBox>
                </td>
                <td style="display: none">
                    <asp:TextBox ID="tttodate" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="4">
                    <%--<asp:LinkButton ID="lnkdaysslab" runat="server" Width="90px" CssClass="button1" Text="Days Slab"></asp:LinkButton>--%>
                    <asp:Button ID="btndayslb" runat="server" Width="90px" CssClass="button1" Text="Days Slab">
                    </asp:Button>
                    <asp:Button ID="btnadcomm" Width="90px" runat="server" CssClass="button1" Text="Additional Comm">
                    </asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnclose" runat="server" CssClass="button1" OnClick="btnclose_Click">
                    </asp:Button>
                    <asp:Button ID="btndelete" runat="server" CssClass="button1"></asp:Button>
                </td>
            </tr>
            <tr>
                <td>
                    <input id="hiddencompcode" type="hidden" size="1" name="hiddencompcode" runat="server" />
                    <input id="hiddenretcode" type="hidden" size="1" name="hiddenretcode" runat="server" />
                    <input id="hiddenuserid" type="hidden" size="9" name="hiddenuserid" runat="server" />
                    <input id="hiddendateformat" type="hidden" name="hiddendateformat" runat="server" />
                    <input id="hiddenshow" type="hidden" name="hiddendateformat" runat="server" />
                    <input id="hiddendelsau" type="hidden" name="hiddendateformat" runat="server" />
                    <input id="hiddenccode" type="hidden" name="hiddendateformat" runat="server" />
                    <input id="hiddenenln" type="hidden" name="hiddenenln" runat="server" />
                    <input id="hiddensubmod" type="hidden" name="hiddenenln" runat="server" />
                      <input id="hiddenchk" type="hidden" name="hiddenenln" runat="server" />
                    <input id="hiddenstructcode" type="hidden" name="hiddendateformat" runat="server" />
                    <input id="hiddenpublicationcode" type="hidden" name="pub" runat="server" />
                    <input id="hiddenflag" type="hidden" name="pub" runat="server" />
                    <input id="hiddenflag2" type="hidden" name="pub" runat="server" />
                </td>
            </tr>
        </tbody>
    </table>
    </form>
    <%--</table>--%>
    <%--</div>--%>
</body>
</html>
