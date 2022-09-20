<%@ Page Language="C#" AutoEventWireup="true" CodeFile="changeexecutive.aspx.cs" Inherits="changeexecutive"  EnableEventValidation="false"%>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<script type="text/javascript" language="javascript" src="javascript/popupcalender.js"></script>
<script type="text/javascript" language="javascript" src="javascript/changeexecutive.js"></script>
  <script language="javascript" type="text/javascript" src="javascript/popupcalender.js"></script>
      <script language="javascript" type="text/javascript" src="javascript/Validations.js"></script>
      <script language="javascript" type="text/javascript" src="javascript/datevalidation.js"></script>

<link href="css/main.css" type="text/css" rel="stylesheet"/>
    <title>change executive</title>
</head>
<body onkeydown="javascript:return tabvalue1(event);" onload="javascript:return clearall();" leftMargin="0" topmargin="0">
    <form id="form1" runat="server">
    
     <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
    
    
    <div id="div1" style="position: absolute; top: 0px; left: 0px; border: none; display: none;
            z-index: 1; " >
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td style="border: 1px">
                        <asp:ListBox ID="lstagency" Width="350px" Height="80px" runat="server" CssClass="btextlist">
                        </asp:ListBox></td>
                </tr>
            </table>
        </div>
        
          <div id="div2" style="position: absolute; top: 0px; left: 0px; border: none; display: none;
            z-index: 1; " >
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td style="border: 1px">
                        <asp:ListBox ID="lstexecutive" Width="350px" Height="80px" runat="server" CssClass="btextlist">
                        </asp:ListBox></td>
                </tr>
            </table>
        </div>

         <div id="div3" style="position: absolute; top: 0px; left: 0px; border: none; display: none;
            z-index: 1; " >
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td style="border: 1px">
                        <asp:ListBox ID="lstclientname" Width="350px" Height="80px" runat="server" CssClass="btextlist">
                        </asp:ListBox></td>
                </tr>
            </table>
        </div>

         <div id="div4" style="position: absolute; top: 0px; left: 0px; border: none; display: none;
            z-index: 1; " >
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td style="border: 1px">
                        <asp:ListBox ID="lstretainer" Width="350px" Height="80px" runat="server" CssClass="btextlist">
                        </asp:ListBox></td>
                </tr>
            </table>
        </div>
        
         <div id="div5" style="position: absolute; top: 0px; left: 0px; border: none; display: none;
            z-index: 1; " >
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td style="border: 1px">
                        <asp:ListBox ID="listadd" Width="350px" Height="80px" runat="server" CssClass="btextlist">
                        </asp:ListBox></td>
                </tr>
            </table>
        </div>

         <div id="divclient" style="position: absolute; top: 0px; left: 0px; border: none;
            display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        
                                <asp:ListBox ID="lstclient" Width="350px" Height="65px" runat="server" CssClass="btextlist">
                                </asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
         <div id="div6" style="position: absolute; top: 0px; left: 0px; border: none;
            display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        
                                <asp:ListBox ID="lstagen" Width="350px" Height="65px" runat="server" CssClass="btextlist">
                                </asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
    
    
    
    <table id="OuterTable" width="980" align="center" border="0" cellpadding="0" cellspacing="0">
    <tr >
    <td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Ad Booking Audit"></uc1:topbar></td>
    </tr>
    
    </table>
    
   
  	<table border="0" align="center" width="100%" cellpadding="0" cellspacing="0" style="width:auto;margin:15px 30px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:155PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Change Executive/Change Client</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>  
    
   <table  style="margin-left:250px">
<tr>



<td align="left">
<asp:Label id="lbDateFrom" runat="server" CssClass="TextField"></asp:Label></td>
<td style="HEIGHT: 25px" align="left">
<asp:TextBox id="txtfrmdate" runat="server" CssClass="btext1" ></asp:TextBox>
<img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txtfrmdate, "mm/dd/yyyy")' onfocus="abc();" height=14 width=14/>
</td>
<td align="left">
<asp:Label id="lbToDate" runat="server" CssClass="TextField"></asp:Label></td>
<td style="HEIGHT: 25px" align="left">

<asp:TextBox id="txttodate1" runat="server" CssClass="btext1" ></asp:TextBox>
<img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txttodate1, "mm/dd/yyyy")' onfocus="abc();" height=14 width=14/>
</td>
</tr>



<tr>
<td align="left"><asp:Label id="lblagency" runat="server" CssClass="TextField"></asp:Label></td>
<td style="HEIGHT: 25px" align="left">
<asp:TextBox id="txtagency1" runat="server" CssClass="dropdown" >
</asp:TextBox>
</td>
<td align="left"><asp:Label id="lblclient" runat="server" CssClass="TextField"></asp:Label></td>
<td style="HEIGHT: 25px" align="left">
<asp:TextBox id="txtclient1" runat="server" CssClass="dropdown" >
</asp:TextBox>
</td>
</tr>


<tr>

<td align="left"><asp:Label id="lblciod" runat="server" CssClass="TextField"></asp:Label></td>
<td style="HEIGHT: 25px" align="left">
<asp:TextBox id="txtciod" runat="server" CssClass="dropdown" >
</asp:TextBox>
</tr>
			
			
<tr>
<td colspan="2" align="right">

<asp:UpdatePanel ID="up60" runat="server"><ContentTemplate>
 <asp:button id="btnsubmit" runat="server" CssClass="button1" Text="Submit" 
        onclick="btnsubmit_Click"></asp:button>
         <asp:button id="btnexit" runat="server" CssClass="button1" Text="Exit" 
        ></asp:button>
        
        </ContentTemplate></asp:UpdatePanel>
</td>							
</tr>                                          	
                                                      
   </table>
   
 <%--  <table><tr><td >--%>
 
  
    <div id="divgrid1"  align="center"  runat="server" style="display:block; OVERFLOW: auto;width:750px;height:400px;margin-left:200px" >
    
    
   <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
   <asp:datagrid    id="DataGrid1" runat="server" CssClass="dtGrid" 
                                        AllowSorting="True" AutoGenerateColumns="False" 
											Width="600px" onitemdatabound="DataGrid1_ItemDataBound" >
											<SelectedItemStyle BackColor="#046791"></SelectedItemStyle>
											<HeaderStyle HorizontalAlign="Center" Height="20px" 
                                                CssClass="dtGridHd" BackColor="#7DAAE3" Font-Bold="True" ForeColor="White"></HeaderStyle>
											<Columns>
											 <asp:BoundColumn HeaderText="CIOBOOKING" SortExpression="CIOBOOKING" DataField="CIOBOOKING" >
											    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
											    </asp:BoundColumn>
												
												<asp:BoundColumn DataField="AGENCY" SortExpression="AGENCY" HeaderText="AGENCY">
												<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												
												
														<asp:BoundColumn DataField="CATEGORY" SortExpression="CATEGORY" HeaderText="CATEGORY">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												
												
												<asp:BoundColumn DataField="SUBCATEGORY" SortExpression="SUBCATEGORY" HeaderText="SUBCATEGORY">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												
												
													<asp:BoundColumn DataField="RONO" SortExpression="RONO" HeaderText="RONO">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
									
													<asp:BoundColumn DataField="CLIENT_NAME" SortExpression="CLIENT_NAME" HeaderText="CLIENT NAME">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												
                                                <asp:BoundColumn DataField="Client_address" SortExpression="Client_address" HeaderText="CLIENT ADD">
													<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
                                            
											   <asp:BoundColumn HeaderText="RETAINER"  SortExpression="RETAINER" DataField="RETAINER">
											    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center" CssClass="btext1"></ItemStyle>
											    </asp:BoundColumn>
											
                                                 <asp:BoundColumn HeaderText="EXECUTIVE"  SortExpression="EXECUTIVE" DataField="EXECUTIVE">
											    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle><ItemStyle HorizontalAlign="Center" CssClass="btext1"></ItemStyle>
											    </asp:BoundColumn>

											<%--    <asp:TemplateColumn HeaderText="EXECUTIVE">
												<ItemTemplate>
													</ItemTemplate>
												</asp:TemplateColumn>
											    --%>
											    
											    <asp:TemplateColumn HeaderText="Update" >
												<ItemTemplate >
													</ItemTemplate>
												</asp:TemplateColumn>
											
											</Columns>
										</asp:datagrid>
										
									</ContentTemplate></asp:UpdatePanel>
   </div>
 
     <%--  </td></tr></table>--%>
   
   <input id="hiddendateformat" type="hidden" name="hiddendateformat" runat="server"/>
    <input id="hiddencompcode" type="hidden" size="1" name="hiddencomcode" runat="server"/>
   <input id="hiddenuserid" type="hidden" size="1" name="Hidden1" runat="server"/>
     <input id="Hiddenclientcode" type="hidden" name="hidattach1" runat="server" />
     <input id="Hiddenagencycode" type="hidden" name="hidattach1" runat="server" />
     <input id="hdnglobalid" type="hidden" name="hdnglobalid" runat="server" />
      <input id="hdnexecutive" type="hidden" name="hdnglobalid" runat="server" />
      <input id="hdnclientcode" type="hidden" name="hdnclientcode" runat="server" />
    <input id="hdncode" type="hidden" name="hdncode" runat="server" />
    <input id="hdncodesubcode" type="hidden" name="hdncodesubcode" runat="server" />
      <input id="HDNCLIENT" type="hidden" name="hdnglobalid" runat="server" />
         <input id="HDNAGENCY" type="hidden" name="hdnglobalid" runat="server" />
        <input id="hdnretainer" type="hidden" name="hdnglobalid1" runat="server" />
           <input id="hdnretainername" type="hidden" name="hiddeneditionname" runat="server" />
        <input id="Hidden1" type="hidden" name="hdnglobalid" runat="server" />
          <input type="hidden" id="hiddensupplimentflag" runat="server"/>
        <input type="hidden" id="hiddensupplementbilldate" runat="server"/>
         <input type="hidden" id="hiddensupplementbillno" runat="server"/>
         <input type="hidden" id="hiddencentcode" runat="server"/>
         <input type="hidden" id="hiddenbranchcode" runat="server"/>
   <%-- </div>--%>
    </form>
</body>
</html>
