<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProofReading.aspx.cs" Inherits="ProofReading"  EnableEventValidation="false"%>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title id="tit" runat="server">ProofReading</title>
        <link href="css/main.css" type="text/css" rel="stylesheet"/>
     <script language="javascript" src="javascript/Pub_Cent_Box_Add.js" type="text/javascript"></script>
     <script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
     <script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
     <script type="text/javascript" language="javascript" src="javascript/popupcalender.js"></script>
     <script type="text/javascript" language="javascript" src="javascript/datevalidation.js"></script>
     <script type="text/javascript" language="javascript" src="javascript/ProofReading.js"></script>
<script type="text/javascript" language="javascript" >
    function notchar8(event) {
        var browser = navigator.appName;
        if (browser != "Microsoft Internet Explorer") {
            if ((event.which >= 48 && event.which <= 57) || (event.which == 127) || (event.which == 8) || (event.which == 9) || (event.which == 47) || (event.which == 0)) {
                return true;
            }
            else {
                return false;
            }
        }
        else {
            if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 127) || (event.keyCode == 8) || (event.keyCode == 9) || (event.keyCode == 47)) {
                return true;
            }
            else {
                return false;
            }
        }
    }

</script>
</head>
<body id="bdy" onkeydown="javascript:return tabvalue(event,'txtpunboxadd')"; style="background-color:#f3f6fd;">
    <form id="form1" runat="server">
   <div id="div1" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lst_user" Width="360px" Height="185px" runat="server" CssClass="dropdown" ></asp:ListBox></td></tr></table></div>
    
       <table id="OuterTable" width="1000" border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server"></uc1:topbar></td>
				</tr>
				<%--<tr valign="top">
					<td valign="top" style="width: 184px; height:60px;">
						<table border="0" cellpadding="0" cellspacing="0" >
							<tr valign="top" style="height:26px">
								<td valign="baseline" colspan="3">
									<div id="Leftbar1_tP1" class="topbarclock1"><span id="Leftbar1_lbrelease">Release No. 5.0.01</span></div>
								</td>
							</tr>				
						</table>					
					</td>
					<td valign="top">
						<table class="RightTable" id="RightTable" cellpadding="0" cellspacing="0">
							<tr valign="top">
								<td><asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnSave" runat="server" CssClass="topbutton" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnModify" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnQuery" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnExecute" runat="server" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnCancel" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnfirst" CssClass="topbutton" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnprevious" runat="server" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnnext" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnlast" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnDelete" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnExit" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton>
								</td>
							</tr>
							
						</table>
					</td>
				</tr>--%>
			</table>
			<table border="0" cellpadding="0" cellspacing="0" width="100%" style="width:auto;margin:15px 40px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"  ><center><b><%=cap %></b></center></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
            <table  border="0" style="width:auto;margin:40px 200px;">
			    <tr>
					<td>
                        <asp:Label ID="lbFromDate" runat="server" CssClass="TextField"></asp:Label></td>
				    <td>
                        <asp:TextBox ID="txtFromDate" runat="server" onpaste="return false;" onkeypress="return notchar8(event);" CssClass="btext1"></asp:TextBox>
                        
                    
                    <script language="javascript" type="text/javascript">
                        if (!document.layers) {
                            document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txtFromDate, \"mm/dd/yyyy\")' height=14 width=14> ")
                        }				
			            </script>
                    </td>
                    
                    <td>
                        <asp:Label ID="lbToDate" runat="server" CssClass="TextField"></asp:Label></td>
				    <td>
                        <asp:TextBox ID="txtToDate" runat="server" onpaste="return false;"  onkeypress="return notchar8(event);" CssClass="btext1"></asp:TextBox>
                   
                        <script language="javascript" type="text/javascript">
                            if (!document.layers) {
                                document.write("<img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txtToDate, \"mm/dd/yyyy\")' height=14 width=14> ")
                            }				
			            </script>    
                    </td>
				</tr>
				<tr>
					<td><asp:Label id="lblcategory" runat="server" CssClass="TextField"></asp:Label></td>
					<td><asp:DropDownList  id="drpadvcatcode" runat="server" CssClass="dropdown"
							MaxLength="8"></asp:DropDownList></td>
					<td><asp:label id="AdCategoryName" runat="server" CssClass="TextField"></asp:label></td>
					<td><asp:dropdownlist id="drpadvsubcatcode" runat="server" CssClass="dropdown"></asp:dropdownlist></td>
					</tr>
					<tr>
					<td><asp:Label id="lblfilter" runat="server" CssClass="TextField"></asp:Label></td>
					<td><asp:DropDownList  id="drpfilter" runat="server" CssClass="dropdown">
					<asp:ListItem Value="0">---Select---</asp:ListItem>
					<asp:ListItem Value="PUB">Based on Publish Date</asp:ListItem>
					<asp:ListItem Value="BOOK">Based on Booked Date</asp:ListItem></asp:DropDownList></td>
					<td><asp:Label id="lblinsertiontype" runat="server" CssClass="TextField"></asp:Label></td>
					<td><asp:dropdownlist id="InsertionType" runat="server" CssClass="dropdown">
					<asp:ListItem Value="0">-----Select------</asp:ListItem>
					<asp:ListItem Value="ALL">All Ads</asp:ListItem>
					<asp:ListItem Value="NONREPEATE">Booked Ads</asp:ListItem>
					<asp:ListItem Value="REPEATE"> Repeat Ads</asp:ListItem>
					<asp:ListItem Value="PROOFED">Proofed Ads</asp:ListItem>
					<asp:ListItem Value="UNPROOFED">Unproofed Ads</asp:ListItem>
					</asp:dropdownlist></td>
					
					
				</tr>
	<tr>		
	<td><asp:Label ID="lblbooktyp" runat="server" CssClass="TextField"> Login Type</asp:Label></td>
     <td><asp:DropDownList ID="drpbooktyp" runat="server" CssClass="dropdown">
     <asp:ListItem Value="A" Text="All"></asp:ListItem>
     <asp:ListItem Value="D" Text="Company"></asp:ListItem>
     <asp:ListItem Value="Q" Text="Agency"></asp:ListItem>
     </asp:DropDownList></td>
     
     
					   <td><asp:Label id="lbluserid" runat="server"    CssClass="TextField"></asp:Label></td>
					<td><asp:TextBox  id="drpuserid" runat="server" CssClass="btext1" ></asp:TextBox></td></tr>	
					<tr><td><asp:Label ID="lblbranch" runat="server" CssClass="TextField"> Branch<%--<font color="red">*</font>--%></asp:Label></td>
     <td><asp:DropDownList ID="drpbranch" runat="server" CssClass="dropdown"></asp:DropDownList></td>
      <td><asp:Label id="Label1" runat="server"    CssClass="TextField">Booking ID/ Receipt No</asp:Label></td>
					<td><asp:TextBox  id="bookingid" runat="server" CssClass="btext1" ></asp:TextBox></td></tr>	
					</tr>
					
					
					<tr>  
      <td><asp:Label id="lblprintingcenter" runat="server"    CssClass="TextField">Printing center<font color='red'>*</font></asp:Label></td>
      <td><asp:DropDownList ID="dpd_printcent" runat="server" CssClass="dropdown"></asp:DropDownList></td>
</tr>
					
				<tr><td colspan="3">&nbsp;&nbsp;&nbsp;</td>
				<td> <asp:button id="btnSubmit" CssClass="topbutton" Runat="server" Width="63px" 
                        Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" 
                        BorderColor="DarkGray"  Height="24px" Text="Submit" onclick="btnSubmit_Click"></asp:button>
                     <asp:button id="btnExit" CssClass="topbutton" Runat="server" Width="63px" Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray"  Height="24px" Text="Exit"></asp:button></td>
                  
				</tr>
				</table>
				<table style="width:auto;margin:-10px 20px;" id="tbl1">
				<tr>
				<td> <%--OnPageIndexChanged="DataGrid2_PageIndexChanged" PageSize="50" OnItemDataBound="DataGrid2_ItemDataBound" --%>
				<div style="OVERFLOW: auto; WIDTH:900px; HEIGHT: 200px">
                    <asp:datagrid id="DataGrid2" runat="server" CssClass="dtGrid" Width="880px"	
                        AutoGenerateColumns="False" onitemdatabound="DataGrid2_ItemDataBound" 
                        onpageindexchanged="DataGrid2_PageIndexChanged"  >
						<SelectedItemStyle BackColor="#046791" ></SelectedItemStyle>
						<HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></HeaderStyle>
						<Columns>
						   <asp:BoundColumn DataField="RowNumber" HeaderText="Sr. No.">
								<ItemStyle HorizontalAlign="Left" BackColor="White" BorderColor="#7DAAE3"></ItemStyle>
							</asp:BoundColumn>
							<asp:BoundColumn DataField="cio_booking_id" HeaderText="Booking Id">
								<ItemStyle HorizontalAlign="Left" BackColor="White" BorderColor="#7DAAE3"></ItemStyle>
							</asp:BoundColumn>
							<asp:BoundColumn DataField="AGENCY" HeaderText="Agency">
								<ItemStyle HorizontalAlign="Left" BackColor="White" BorderColor="#7DAAE3"></ItemStyle>
							</asp:BoundColumn>
							<asp:BoundColumn DataField="RO_No" HeaderText="RO No"  >
								<ItemStyle HorizontalAlign="Left" BackColor="White" BorderColor="#7DAAE3"></ItemStyle>
							</asp:BoundColumn>
							<asp:BoundColumn DataField="Adv_Cat_Name" HeaderText="Category"  >
								<ItemStyle HorizontalAlign="Left" BackColor="White" BorderColor="#7DAAE3"></ItemStyle>
							</asp:BoundColumn>
							<asp:BoundColumn DataField="Adv_Subcat_Name" HeaderText="Sub Category"  >
								<ItemStyle HorizontalAlign="Left" BackColor="White" BorderColor="#7DAAE3"></ItemStyle>
							</asp:BoundColumn>
							<asp:BoundColumn DataField="Filename" HeaderStyle-Width='180px' HeaderText="FileName">
								<ItemStyle HorizontalAlign="Left" BackColor="White" BorderColor="#7DAAE3"></ItemStyle>
							</asp:BoundColumn>
							
							<asp:TemplateColumn HeaderStyle-Width='1px' HeaderText="">
							<ItemTemplate></ItemTemplate>
							</asp:TemplateColumn>
							
							<asp:TemplateColumn HeaderText="Preview">
							<ItemTemplate></ItemTemplate>
							</asp:TemplateColumn>
							
							<asp:TemplateColumn HeaderText="Details">
							<ItemTemplate></ItemTemplate>
							</asp:TemplateColumn>
							
							<asp:TemplateColumn HeaderText="Publ. Detail">
							<ItemTemplate></ItemTemplate>
							</asp:TemplateColumn>
							<asp:BoundColumn DataField="Agency_sub_code" HeaderText="Agencycode" Visible="false">
							</asp:BoundColumn>
							
							<asp:TemplateColumn HeaderText="package" Visible="false">
							<ItemTemplate></ItemTemplate>
							</asp:TemplateColumn>
							<asp:BoundColumn DataField="PACKAGE_CODE" HeaderText="PACKAGE_CODE" Visible="false">
							</asp:BoundColumn>
							
							<asp:TemplateColumn HeaderText="multifilename" Visible="false">
							<ItemTemplate></ItemTemplate>
							</asp:TemplateColumn>
							<asp:BoundColumn DataField="MULTIFILENAME" HeaderText="MULTIFILENAME" Visible="false">
							</asp:BoundColumn>
							
						</Columns>
						<FooterStyle HorizontalAlign="Center" Height="20px" Font-Bold="True" />
                        <PagerStyle NextPageText="Next" PrevPageText="Prev" Font-Bold="True" BackColor="#7DAAE3" />
													</asp:datagrid></div>
				</td>
                <%--<td align="right;" ></td>--%>
				</tr><tr><td>&nbsp;&nbsp;&nbsp;&nbsp;</td></tr>
				<tr><td align="right"><asp:button id="btnPrev" CssClass="topbutton" Runat="server" 
                        Width="63px" Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" 
                        BorderColor="DarkGray"  Height="24px" Text="Proof" 
                        onclick="btnPrev_Click" ></asp:button><%--<asp:button id="btnpub" CssClass="topbutton" Runat="server" 
                        Width="65px" Font-Size="XX-Small" BackColor="Control" BorderStyle="Outset" 
                        BorderColor="DarkGray"  Height="24px" Text="publication"    ></asp:button>--%></td></tr>
			</table>
				<input id="hiddencompcode" type="hidden" size="5" name="hiddenregion" runat="server"  />	
				<input id="hiddenuserid" type="hidden" size="5" name="Hidden1" runat="server" />
				<input id="hiddendateformat" type="hidden" size="5" name="hiddenregion" runat="server" />
				<input id="hiddencat2" type="hidden" size="15" name="hiddenregion" runat="server" />
				<input id="hiddenuserhome" type="hidden" size="15" name="hiddenregion" runat="server" />
				<input id="hiddenrevenue" type="hidden" size="15" name="hiddenregion" runat="server" />
				<input id="usercode" type="hidden" runat="server"/>
				<input id="hiddenprtype" type="hidden" runat="server"/>
				<input id="hdnusername" type="hidden" runat="server"/>
		<input id="hiddenadmin" type="hidden" size="15" name="hiddenregion" runat="server" />
				 
	   <div id = "dvmainpackage"  runat="server" 
           style="top:300px;left:500px;position:absolute;background-color:#FFFF99; width:250px;display:none;">
    <table cellpadding="0" cellspacing="0"  align="right" style="top: 10px">
        
        <tr>
            <td style="border:solid 1px black;">
                <div id="dvdate"  runat="server" style="OVERFLOW: auto;width:250px;height:150px;top:100px;border-left-color:WindowFrame;"  >
                                   
                   
                    </div>
            </td>
        </tr>
        <tr>
                <td width="10px;">
                </td>
            </tr>
            <tr>
                <td  style="border-bottom:solid 1px black; border-right:solid 1px black;border-left:solid 1px black;">
                        <input id="Button2" type="button" runat="server" onclick="cancelpack()" value="Cancel" />                    
                </td>
                <td>
                        
                </td>
            </tr>
    </table>
    </div>
    </form>
</body>
</html>
