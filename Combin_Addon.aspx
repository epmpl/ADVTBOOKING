<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Combin_Addon.aspx.cs" Inherits="Combin_Addon" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Combination Master Add On</title>
    <link href="css/main.css" type="text/css" rel="stylesheet"/>
    <script language="javascript" type="text/javascript" src="javascript/CombinationMaster.js"></script>
    <script language="javascript" type="text/javascript" src="javascript/entertotabpopup.js"></script>
    <script language="javascript" type="text/javascript">
    function numeric()
    {
    //alert(event.keyCode);
            if ((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==9)||(event.keyCode==11)||(event.keyCode==46))
	        {
	        return true;
	        }
	        else
	        {
	        return false;
	        }
	       	       
	      
    }
    
    
    function rateenter()
{
//alert(event.keyCode);

if((event.keyCode>=46 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9))
{
return true;
}
else
{
return false;
}
}
    
    
    function chkuom(e)
{
//return allamount121(e);



var fld=e.value;
		if(fld!="")
			{
			//var expression= ^-{0,1}\d*\.{0,1}\d+$;
			if(fld.match(/^\d+(\.\d{1,2})?$/i))
			{
			//return true;
			}
			else
			{
			alert("Input error")
			//alert(e.id);
			var str=e.id;
			e.value="";
			document.getElementById(str).focus();
			//e.id.focus();
			return false;
			}
			}
			}

    </script>
</head>
<body onkeydown="javascript:return tabvalue('txtrate');">
    <form id="form1" runat="server">
   
        <table border="1" cellpadding="0" cellspacing="0" style="border-color:Black;">
        <tr>
        
                <td>
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                    <table id="Table4" align="center" bgcolor="#7daae3" border="0" cellpadding="0" cellspacing="0" width="633">
                        <tr>
                    <td align="center" class="btnlink" style="height: 10px">
                    Add On</td>
                        </tr>
                    </table>
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
    
                    <table width="90%" cellpadding="0" cellspacing="0">
                        <tr style="display:none;">
                            <td align="left">
                                <asp:Label ID="lblpkg" runat="server" CssClass="TextField"></asp:Label></td>
                            <td align="left">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                <asp:TextBox ID="txtpkg" runat="server" CssClass="btext1" Enabled="False"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblpkgdecs" runat="server" CssClass="TextField"></asp:Label></td>
                            <td align="left">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                <asp:TextBox ID="txtdesc" runat="server" CssClass="btext1" Enabled="False"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblpublication" runat="server" CssClass="TextField">Publication</asp:Label></td>
                            <td align="left">
                                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                    <ContentTemplate>
                                <asp:DropDownList ID="drppub" runat="server" CssClass="dropdown" OnSelectedIndexChanged="drppub_SelectedIndexChanged" AutoPostBack="True" Enabled="False">
                                </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td align="left">
                                <asp:Label ID="lbledition" runat="server" CssClass="TextField"></asp:Label></td>
                            <td align="left">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="drpedition" runat="server" CssClass="dropdown"  Enabled="False">
                                        <asp:ListItem Value="0">-Select Edition-</asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            </td>
                        </tr>
                       
                        <tr>
                            <td align="left">
                               <asp:Label ID="lblnoofinsert" runat="server" CssClass="TextField">No Of Insert</asp:Label>
                            </td>
                            <td align="left">
                            <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                    <ContentTemplate>
                                <asp:TextBox ID="txtnoofinsert" runat="server" CssClass="numerictext" Enabled="False" onkeypress="javascript:return isNumberKey(event);" MaxLength="3"></asp:TextBox>
                                
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td >
                            
                            </td>
                             <td align="left">
                            <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                    <ContentTemplate>
                                
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                        <td></td><td></td><td></td>
                        <td align="right" >
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnsubmit" runat="server" CssClass="button1" OnClick="btnsubmit_Click1" /><asp:Button ID="btnclear" runat="server" CssClass="button1" OnClick="btnclear_Click" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                            <div id="firgri" runat="server" style="overflow:auto;  width:90%;">
                                
                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                    <ContentTemplate>
                    <asp:DataGrid ID="DataGrid1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                        CssClass="dtGrid" width="100%" OnItemDataBound="DataGrid1_ItemDataBound" OnSortCommand="abc">
                        <SelectedItemStyle BackColor="#046791" Font-Size="XX-Small" />
                        <PagerStyle HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#7DAAE3" CssClass="dtGridHd12" ForeColor="White" Height="20px"
                            HorizontalAlign="Center" />
                        <Columns>
                            <asp:TemplateColumn></asp:TemplateColumn>
                            <asp:BoundColumn HeaderText="Pubcode" DataField="Pubcode"  Visible="false"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Publication" HeaderText="Publication"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Edition_code" DataField="Edition_code"  Visible="false" ></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Edition" DataField="Edition" ></asp:BoundColumn>
                            <asp:BoundColumn DataField="noofinsert" HeaderText="Inserts"></asp:BoundColumn>
                            <asp:BoundColumn DataField="ADON_CODE" HeaderText="ADON_CODE" Visible="false"></asp:BoundColumn>
                        </Columns>
                    </asp:DataGrid>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <!--</div>-->
                                <!--<div id="secgri" runat="server" style="overflow:auto;  width:90%;">-->
                                
                                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                    <ContentTemplate>
                    <asp:DataGrid ID="DataGrid2" runat="server"  AutoGenerateColumns="False"
                        CssClass="dtGrid" width="100%">
                        <SelectedItemStyle BackColor="#046791" Font-Size="XX-Small" />
                        <PagerStyle HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#7DAAE3" CssClass="dtGridHd12" ForeColor="White" Height="20px"
                            HorizontalAlign="Center" />
                        <Columns>
                           <asp:BoundColumn HeaderText="Pubcode" DataField="Pubcode" Visible="false"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Publication" HeaderText="Publication"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Edition_code" DataField="Edition_code"  Visible="false"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Edition" DataField="Edition" ></asp:BoundColumn>
                            <asp:BoundColumn DataField="noofinsert" HeaderText="Inserts"></asp:BoundColumn>
                        </Columns>
                    </asp:DataGrid>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                </div>
                    </td>
                        </tr>
                        <tr>
                            <td align="right" style="height: 114px">
                            <table width="590px"  cellpadding="0" cellspacing="0">
                            <tr><td style="width:345px"><asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                    <ContentTemplate></ContentTemplate></asp:UpdatePanel></td><td style="width:145px">
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                    <ContentTemplate>
                                    <asp:Button ID="btnclose" runat="server"  CssClass="button1" /><asp:Button ID="btndelete" runat="server" CssClass="button1" OnClick="btndelete_Click" Enabled="False" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                </td></tr></table></td>
                        </tr>
                        <tr>
                            <td>
                    <table id="Table6" align="center" bgcolor="#7daae3" border="0" cellpadding="0" cellspacing="0"
                                width="634">
                                <tr>
                                    <td align="center" style="height: 19px">
                                    </td>
                                </tr>
                            </table>
                            </td>
                        </tr>
                    </table>
                    </td>
            </tr>
        </table>
        <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                    <ContentTemplate>
        <input id="hiddenuserid" runat="server" type="hidden" />
        <input id="hiddencomcode" runat="server" type="hidden" />
        <input id="hiddendateformat" runat="server" type="hidden" />
        <input id="hiddenratecode" runat="server" type="hidden" />
        <input id="hiddencode" runat="server" type="hidden" />
        <input id="hiddenpkgcode" runat="server" type="hidden" style="width: 38px" />
        <input id="hiddenpkgdesc" runat="server" type="hidden" />
        <input id="hiddenedival" runat="server" type="hidden" />
        <input id="hiddensupval" runat="server" type="hidden" />
        <input id="hiidensanod" runat="server" type="hidden" />
        <input id="hideshow" runat="server" type="hidden" />
        <input id="hiddencombincode" runat="server" type="hidden" style="width: 40px" />
        <input id="hiddentype_agency" type="hidden" name="Hidden2" runat="server" style="width: 15px"/>
        </ContentTemplate></asp:UpdatePanel>
    </form>
</body>
</html>
