<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dealaudit.aspx.cs" Inherits="dealaudit" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew.ascx"%>
<%--<%@ Register TagPrefix="uc1" TagName="Topbar" Src="~/Topbar.ascx" %>--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>DEAL AUDIT</title>
        <link href="css/main.css" type="text/css" rel="stylesheet" >
        <script language="javascript" src="javascript/dealaudit.js"></script>
        <script language="javascript" src="javascript/givepermission.js"></script>
        <script language="javascript" src="javascript/popupcalender.js"></script>
        <script language="javascript" src="javascript/datevalidation.js"></script>
        <script language="javascript" src="javascript/DealDetail_forAudit.js"></script>
        <%--<script language="javascript" src="javascript/dealdetail.js"></script>--%>
        <script type="text/javascript" language="javascript" src="javascript/entertotab.js"></script>
        <style type="text/css">
            .animatedtabs
            {
                border-bottom: 1px solid gray;
                overflow: hidden;
                width: 100%;
                font-size: 14px; /*font of menu text*/
            }
            
             .curs
            {
                cursor:pointer;
            }
            
            .animatedtabs ul
            {
                list-style-type: none;
                margin: 0;
                margin-left: 10px; /*offset of first tab relative to page left edge*/
                padding: 0;
            }

            .animatedtabs li
            {
                float: left;
                margin: 0;
                padding: 0;
            }

            .animatedtabs a
            {
                float: left;
                position: relative;
                top: 5px; /* 1) Number of pixels to protrude up for selected tab. Should equal (3) MINUS (2) below */
                background: url(images/tab-blue-left.gif) no-repeat left top;
                margin: 0;
                margin-right: 3px; /*Spacing between each tab*/
                padding: 0 0 0 9px;
                text-decoration: none;
            }

            .animatedtabs a span
            {
                float: left;
                position: relative;
                display: block;
                background: url(images/tab-blue-right.gif) no-repeat right top;
                padding: 5px 14px 3px 5px; /* 2) Padding within each tab. The 3rd value, or 3px, should equal (1) MINUS (3) */
                font-weight: bold;
                color: black;
            }

            /* Commented Backslash Hack hides rule from IE5-Mac \*/
            .animatedtabs a span {float:none;}
            /* End IE5-Mac hack */


            .animatedtabs .selected a
            {
                background-position: 0 -125px;
                top: 0;
            }

            .animatedtabs .selected a span
            {
                background-position: 100% -125px;
                color: black;
                padding-bottom: 8px; /* 3) Bottom padding of selected tab. Should equal (1) PLUS (2) above */
                top: 0;
            }

            .animatedtabs a:hover
            {
                background-position: 0% -125px;
                top: 0;
            }

            .animatedtabs a:hover span
            {
                background-position: 100% -125px;
                padding-bottom: 8px; /* 3) Bottom padding of selected tab. Should equal (1) PLUS (2) above */
                top: 0;
            }
            .tdcls
            {
                font-size: 10px;
                border-bottom: 0; 
                border-style: solid;
                border-bottom:1px; 
                border-width: 1px;
                font-family: verdana, arial, sans-serif; 
                padding: 0px;
            }
            .tdcls1
            {
                font-size: 10px;
                border-bottom: 0; 
                border-style: solid;
                border-bottom:1px; 
                border-width: 1px;
                font-family: verdana, arial, sans-serif; 
                padding: 0px;
                display:none;
            }
            .style1
            {
                width: 159px;
            }
            .style2
            {
                width: 167px;
            }
        </style>
</head>
<body onkeypress="javascript:return tabvalue1(event);" onclick="javascript:return tabvalue1(event);" onload="javascript:return foc();" style="margin-top:0px;background-color:#f3f6fd;" >
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div id="div1" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1; " >
                <table cellpadding="0" cellspacing="0" >
                    <tr>
                        <td>
                            <asp:ListBox ID="lstagency" Width="350px" Height="80px" runat="server" CssClass="btextlist">
                            </asp:ListBox></td>
                    </tr>
                </table>
         </div>
        <div id="divclient" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        
                                <asp:ListBox ID="lstclient" Width="350px" Height="65px" runat="server" CssClass="btextlist">
                                </asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
         <div id="divdeal" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        
                                <asp:ListBox ID="lstdeal" Width="350px" Height="65px" runat="server" CssClass="btextlist">
                                </asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
        <table id="OuterTable" cellspacing="0" cellpadding="0" width="1000" border="0">
			<tr valign="top">
				<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="DEAL AUDIT"></uc1:topbar></td>
			</tr>    
        </table>
        <table border="0" cellpadding="0" cellspacing="0" width="100%" style="width:auto;margin:15px 40px;">
          <tr>
		     <td style="width:27px;"></td>
             <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
             <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>DEAL AUDIT</center></b></td>
             <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
			 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
           </tr>
        </table>
        <table style="width:auto;margin:5px 10px;">
            <tr>
                <td><asp:Label ID="lbad" runat="server" CssClass="TextField" ></asp:Label></td>
                <td class="style1"><asp:DropDownList ID="drpad" runat="server" CssClass="dropdown3" Width="145px">
                <asp:ListItem Value="sel">--Select--</asp:ListItem>
                <asp:ListItem Value="print">Print</asp:ListItem>
                <asp:ListItem Value="elec" Selected="True">Electronics</asp:ListItem>
                <asp:ListItem Value="print&amp;ele">Print &amp; Electronics</asp:ListItem></asp:DropDownList></td>
                <td align="left"><asp:Label ID="lbvf" runat="server" CssClass="TextField" ></asp:Label></td>
                <td class="style2" ><asp:TextBox ID="davf" runat="server" CssClass="btext1" Enabled="true" MaxLength="10" ></asp:TextBox>
                <img alt ='Images/cal1.gif' src='Images/cal1.gif'  onclick='popUpCalendar(this,form1.davf,"mm/dd/yyyy")' height="14" width="14" /></td>
                <td align="left"><asp:Label ID="lbvt" runat="server" CssClass="TextField" ></asp:Label></td>
                <td ><asp:TextBox ID="davt" runat="server" CssClass="btext1" Enabled="true" MaxLength="10" ></asp:TextBox>
                <img alt ='Images/cal1.gif' src='Images/cal1.gif'  onclick='popUpCalendar(this,form1.davt,"mm/dd/yyyy")' height="14" width="14" /></td>
                
            </tr>
            <tr>
                <td ><asp:Label ID="lbde" runat="server" CssClass="TextField" ></asp:Label></td>
                <td class="style1" ><asp:TextBox ID="txtde" runat="server" CssClass="btext1" Enabled="true"  MaxLength="10" Width="143px"></asp:TextBox></td>
                <td ><asp:label id="AgencyCode" runat="server" CssClass="TextField" ></asp:label></td>
			    <td class="style2"><asp:TextBox ID="drpagencycode"  runat="server"  CssClass="btext1"  AutoPostBack="false"  ></asp:TextBox></td>
                <td><asp:label id="ClientName" runat="server" CssClass="TextField" ></asp:label></td>
			    <td ><asp:TextBox ID="drpclientname" runat="server"  CssClass="btext1" AutoPostBack="false"   ></asp:TextBox></td>
                
                
            </tr>
            <tr>
            <td><asp:Label ID="lbat" runat="server" CssClass="TextField" ></asp:Label></td>
            <td class="style1"><asp:DropDownList ID="drpat" runat="server" CssClass="dropdown3" Width="145px" >
                    <asp:ListItem Value="0">Select Audit Type</asp:ListItem>
                    <asp:ListItem Value="1">Approved</asp:ListItem>
                    <asp:ListItem Value="2">Unapproved</asp:ListItem>
                    </asp:DropDownList></td>
                    <td><asp:Label ID="lblchk" runat="server" CssClass="TextField" ></asp:Label></td>
            <td class="style1"><asp:DropDownList ID="drpchk" runat="server" CssClass="dropdown3" Width="145px" >
                    <asp:ListItem Value="0">Select Rate Type</asp:ListItem>
                    <asp:ListItem Value="A">Above The Base Amt</asp:ListItem>
                    <asp:ListItem Value="B">Below The Base Amt</asp:ListItem>
                    </asp:DropDownList></td>
            <td align="left"><asp:label id="lblremark" runat="server" CssClass="TextField" ></asp:label></td>
            <td align="left" colspan="2">
                <asp:TextBox ID="txtremark"  runat="server"  
                    CssClass="btext1"  AutoPostBack="false" ></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td align="left"><asp:label id="lbllevel" runat="server" CssClass="TextField" ></asp:label></td>
                    <td align="left" colspan="1"><asp:TextBox ID="txtlevel"  runat="server" CssClass="btext1"  Enabled="false" AutoPostBack="false" ></asp:TextBox></td>
                    <td align="left"><asp:TextBox ID="txtlvl1"  runat="server" CssClass="btext1" Enabled="false" AutoPostBack="false" ></asp:TextBox></td>
                    </tr>
                    <tr>
                  <asp:UpdatePanel ID="up1" runat="server"><ContentTemplate>   <td colspan="2" align="right"><asp:button id="approvedby" runat="server" Width="75px" CssClass="button1" Text=" UN Audit"  ></asp:button><asp:button id="btnsubmit" runat="server" CssClass="button1" Text="Submit"  onclick="btnsubmit_Click" ></asp:button>
           <asp:Button ID="btnexit" runat="server" CssClass="button1" Text="Exit"/><asp:Button ID="btnaudit" runat="server" CssClass="button1" Text="Audit" onclick="btnaudit_Click" /></td><td><asp:Button ID="btnclear" runat="server" CssClass="button1" Text="Clear"/></td></ContentTemplate></asp:UpdatePanel>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="0" width="1000" style="display:none" id="tb1" runat="server"><tr valign="top"  ><td >
            <div id="divgrid1"  runat="server" style="display:block;OVERFLOW: auto; vertical-align:top;height:200PX">
                 <table id="Table3">
                     <tr>
                        <td>
                          <asp:UpdatePanel ID="updategrid" runat ="server" > <ContentTemplate >
                               <asp:DataGrid ID="DataGrid1" runat="server" CssClass="dtGrid"  Width="1000"  
                                         AutoGenerateColumns="False" 
                                   onitemdatabound="DataGrid1_ItemDataBound"   >
                                 <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
                                 <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></HeaderStyle>
                               <Columns>
                                    <asp:BoundColumn  DataField="Agency_code" HeaderText="Agency_code" >
			                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			                        </asp:BoundColumn>
                			        <asp:BoundColumn  DataField="Client_code"  HeaderText="Client_code" >
			                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			                        </asp:BoundColumn>
                			        <asp:BoundColumn DataField="Deal_No" HeaderText="Deal No" >
                                        <ItemStyle HorizontalAlign="Center" CssClass="curs"></ItemStyle>
                                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="deal_name" HeaderText="Deal Name" >
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="product_code" HeaderText="Product Code" >
			                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			                        </asp:BoundColumn>
                                    <asp:BoundColumn DataField="CAPTION" HeaderText="CAPTION" >
			                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			                        </asp:BoundColumn>
                                    <asp:BoundColumn  DataField="FROM_DATE" HeaderText="FROM DATE" ReadOnly="True" Visible="true">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Till_DATE" HeaderText="Till_DATE" >
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn   DataField="TOTALVAL" HeaderText="TOTALVAL" >
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
                                    </asp:BoundColumn>

                                   <%-- <asp:BoundColumn   DataField="CONTRACT_RATE" HeaderText="CON. RATE" >
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
                                    </asp:BoundColumn>--%>

                                   <asp:TemplateColumn  >
                                        <HeaderTemplate><input id="Checkbox4" onclick="SelectHi('DataGrid1', this, 'Checkbox4');" type="checkbox" name="Checkbox4" runat="server"/></HeaderTemplate>
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"   > </HeaderStyle>
						                <ItemStyle HorizontalAlign="Center" Width="20px" VerticalAlign="Middle" ></ItemStyle>
		                                <ItemTemplate >
			                                <asp:CheckBox ID="CheckBox1" CssClass="TextField1" Runat="server"  />
		                                </ItemTemplate>
								    </asp:TemplateColumn>
                			    </Columns>
                             </asp:DataGrid>
                           </ContentTemplate></asp:UpdatePanel>
                        </td>
                     </tr>
                 </table>
            </div>            
         </td></tr></table>
         <table cellpadding="0" cellspacing="0" border="0" style="margin:15px 0px 0px 0px;"><tr><td valign="top">
            <div id="divcommon" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1; " >
                <table cellpadding="0" cellspacing="0" >
                    <tr>
                        <td>
                            <asp:ListBox ID="lstcommon" Width="350px" Height="80px" runat="server" CssClass="btextlist"></asp:ListBox>
                        </td>
                    </tr>
                </table>
            </div>
                <div>
                        <div class="animatedtabs">
                            <ul>
                                <li class="selected" id="an_print"><a href="#" style="cursor:hand"   title="Print" onclick="return openPrint();"><span class="TextField">Print</span></a></li>
                                <li id="an_elec"><a href="#"  style="cursor:hand" title="Electronics" onclick="return openElectronics();"><span class="TextField">Electronics</span></a></li>
                                <li id="an_web"><a href="#" style="cursor:hand"  title="Web" onclick="return openWeb();"><span class="TextField">Web</span></a></li>
                            </ul>
                        </div>
                        <div id="divprint" style="width:1005px;height:220px;overflow:auto;position:absolute;">
                            <table bordercolor="#7DAAE5" border="1px" cellpadding="0" cellspacing="0" id="tblGrid" name="tblGrid" style="position:relative;border-collapse: collapse;" border="1">
                                <thead>
                                    <tr bgcolor="#a1c0ee">
                                        <td class="tdcls" width="60">Ad Type</td>
                                        <td class="tdcls" width="60">Hue</td>
                                        <td class="tdcls" width="60">Uom</td>
                                        <td class="tdcls" width="170">Package</td>
                                        <td class="tdcls" width="100">Category</td>
                                        <td class="tdcls" width="100">Premium</td>
                                        <td class="tdcls" width="50">Card Prem</td>
                                        <td class="tdcls" width="50">Contract Prem</td>
                                        <td class="tdcls" width="50">Contract Rate</td>
                                        <td class="tdcls" width="50">Card Rate</td>
                                        <td class="tdcls" width="50">Deviation</td>
                                        <td class="tdcls" width="50">Disc Type</td>
                                        <td class="tdcls" width="50">Disc. Per.</td>
                                        <td class="tdcls" width="50">Disc On</td>
                                        <td class="tdcls" width="50">Min Size</td>
                                        <td class="tdcls" width="50">Max Size</td>
                                        <td class="tdcls" width="50">Value From</td>
                                        <td class="tdcls" width="50">Value To</td>
                                        <td class="tdcls" width="50">Day</td>
                                        <td class="tdcls" width="50">Insertion</td>
                                        <td class="tdcls" width="50">Comm. Allow</td>
                                        <td class="tdcls" width="50">Deal Start</td>
                                        <td class="tdcls" width="50">Currency</td>
                                        <td class="tdcls" width="50">Rate Code</td>
                                        <td class="tdcls" width="50">Total Rate</td>
                                        <td class="tdcls" width="50">Incentive</td>
                                        <td class="tdcls" width="200">Remarks</td>
                                        <td class="tdcls" width="50">Status</td>
                                        <td class="tdcls" width="50">Position Premium</td>
                                        <td class="tdcls" width="50">Contract Amount</td>
                                        <td class="tdcls" width="50">Contract Position Premium</td>
                                        <td class="tdcls" width="50">Position Prem Disc</td>
                                        <td class="tdcls1" width="50">ID</td>
                                        
                                        
                                        
                                    </tr>
                                </thead>
                                    <tr>
                                        <td class="tdcls"></td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls">0</td>
                                        <td class="tdcls">0</td>
                                        <td class="tdcls">0</td>
                                        <td class="tdcls">0</td>
                                        <td class="tdcls">0</td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls">0</td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls"></td> 
                                        <td class="tdcls"></td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls"><%=currency %></td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls1"></td>
                                        
                                    </tr>
                            </table>
                        </div>   
                        <div id="div_electronics" style="display:none;width:1005px;height:220px;overflow:auto;position:absolute;">
                            <asp:Label ID="lblfinalvalue" runat="server" CssClass="TextField" ></asp:Label>
                            <table bordercolor="#7DAAE5" border="1px" cellpadding="0" cellspacing="0" id="tblGridelec" name="tblGridelec" style="position:relative;border-collapse: collapse;overflow:scroll;" border="1">
                                <thead>
                                    <tr bgcolor="#a1c0ee">
                                        <td class="tdcls" width="50" >Channel</td> 
                                        <td class="tdcls1" width="80">Location</td>
                                        <td class="tdcls1" width="100">Adv Type</td>
                                        <td class="tdcls" width="100">Paid/Bonus</td>
                                        <td class="tdcls" width="100">Rate Type</td>
                                        <td class="tdcls" width="100">BTB</td>
                                        <td class="tdcls" width="100">Program Name</td>
                                        <td class="tdcls" width="100">Time Band</td>
                                        <td class="tdcls" width="100">Day</td>
                                        <td class="tdcls" width="100">FCT/NOI/Words</td>
                                        <td class="tdcls1" width="120">Package</td>
                                        <td class="tdcls1" width="100">Value From</td>
                                        <td class="tdcls1" width="100">Value To</td>
                                        <td class="tdcls" width="150">Disc Type</td>
                                        <td class="tdcls" width="150">Disc. Per.</td>
                                        <td class="tdcls" width="100">Premium</td>
                                        <td class="tdcls" width="200">Contract Prem.</td>
                                        <td class="tdcls" width="200">Contract Rate</td>
                                        <td class="tdcls" width="50">Card Rate</td>
                                        <td class="tdcls" width="50">Deviation</td>
                                        <td class="tdcls" width="50">Card Prem</td>
                                        <td class="tdcls" width="50">Min Size</td>
                                        <td class="tdcls" width="50">Max Size</td>
                                        <td class="tdcls" width="50">Currency</td>
                                        <td class="tdcls1" width="50">Deal Start</td>
                                        <td class="tdcls1" width="50">Program Type</td>
                                        <td class="tdcls1" width="50">Category</td>
                                        <td class="tdcls" width="50">Comm. Allow</td>
                                        <td class="tdcls" width="50">Remarks</td>
                                        <td class="tdcls" width="50">Rate Code</td>
                                        <td class="tdcls" width="50">Disc On</td>
                                        <td class="tdcls" width="50">Sponsorship  From</td>
                                        <td class="tdcls" width="50">Sponsorship  To</td>
                                        <td class="tdcls" width="50">Source</td>
                                        <td class="tdcls" width="50">Total Value</td>
                                        <td class="tdcls" width="50">Incentive</td>
                                        <td class="tdcls" width="50">Approved</td>
                                        <td class="tdcls" width="50">Consumed</td>
                                        <td class="tdcls" width="50">Balance</td>
                                        <td class="tdcls1" width="50">ID</td>
                                    </tr>
                                </thead>
                                    <tr>
                                        <td class="tdcls" title="Press F6 for Entering Electronics Detail"></td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls1"></td>
                                        <td class="tdcls1"></td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls1"></td>
                                        <td class="tdcls1"></td>
                                        <td class="tdcls1"></td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls"></td> 
                                        <td class="tdcls"></td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls"><%=currency %></td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls1"></td>
                                        <td class="tdcls1"></td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls1"></td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls"></td>
                                        <td class="tdcls1"></td>
                                    </tr>
                            </table>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
         <table>
            <tr>
                <td>
                    <input id="hiddenrowcount" type="hidden" size="1" name="hiddenrowcount" runat="server" />
			        <input id="hiddenuserid" type="hidden" size="1" name="Hidden1" runat="server" /> 
			        <input id="hidden2" type="hidden" size="1" name="Hidden1" runat="server" /> 
			        <input id="hiddencenter" type="hidden" size="1" name="hiddencenter" runat="server" /> 
			        <input id="hiddendateformat" type="hidden" size="1" name="Hidden2" runat="server" />
			        <input id="hiddencompcode" type="hidden" size="1" name="hiddencompcode" runat="server" />
			        <input id="hiddenusername" type="hidden" name="username" runat="server"/>
			        <input id="hiddenmodify" type="hidden" name="username" runat="server" />
			        <input id="hiddenname" type="hidden" name="username" runat="server" />
				    <input id="hiddenagency" type="hidden" name="username" runat="server" />
				    <input id="hidden1" value="0" type="hidden" name="hiddenrefresh" runat="server" />
				    <input id="hiddenclient" type="hidden" name="username" runat="server" />
				   <input id="hiddendealno" type="hidden" name="username" runat="server" />
				    <input id="hiddencurrency" value="0" type="hidden" name="hiddencurrency" runat="server" />
                    <input id="hiddenconnect" type="hidden" runat="server" />
                    <input id="hiddenbranchcode" type="hidden" runat="server" />
		        </td>
		    </tr>
	    </table>
    </form>
</body>
</html>
