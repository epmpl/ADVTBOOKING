<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cash_recon_form.aspx.cs" Inherits="cash_recon_form" %>
<!DOCTYPE html PUBLIC "-//W3C//Dtd html 4.0 transitional//EN" >
<html  xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<title>Cash Reconcilation</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1"/>
		<meta name="CODE_LANGUAGE" Content="C#"/>
		<meta name="vs_defaultClientscript" content="Javascript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
        <link href="css/store.css" type="text/css" rel="stylesheet"/>
		<script type="text/javascript" language="javascript" src="javascript/popupcalender.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/datevalidation.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
	    <script type="text/javascript"  language="javascript" src="javascript/Validations.js"></script>
        <script type="text/javascript" language="javascript" src="javascript/jquery.min.js"></script>
        <script type="text/javascript"  language="javascript" src="javascript/cash_recon_form.js"></script>
	   
        <style type="text/css">
            .btextforbook {
                margin-bottom: 0px;
            }
            #Table10
            {
                width: 635px;
            }
            #Table9
            {
                width: 665px;
            }
        </style>
	   
</head>
<body onload="onload();">
   <form id="Form1" method="post" runat="server" >
			<table id="Table7" style="Z-INDEX: 101; LEFT: 24px; WIDTH: 798px; POSITION: absolute; TOP: 16px; HEIGHT: 432px"
				borderColor="#000000" cellspacing="0" cellpadding="0" border="1" ms_2d_layout="TRUE">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
				<tr>
					<td valign="top">
						<table id="Table8" style="WIDTH: 790px; HEIGHT: 15px" cellspacing="0" cellpadding="0" width="633"
							align="center"  bgColor="#7daae3" border="0" >
							<tr valign="top">
								<td class="btnlink" align="center" >Cash Reconcilation</td>
							</tr>
                            </table>
                        <table id="Table9"  cellspacing="0" cellpadding="0" align="center" border="0">
							<tr>
								<td align="center">
									<table id="Table10" cellspacing="0" cellpadding="0" align="center" border="0">
										<tr>
										<td colspan="4" ></td>
										</tr>
                                        <tr>
										<td colspan="4" ></td>
										</tr>
										<tr>
											<td align="left" ><asp:Label id="lblcenter" runat="server" CssClass="TextField" Width="150px" ></asp:Label></td>
											<td align="left" ><asp:textbox  Height="15px" id="txtcenter" runat="server" CssClass="btext1" MaxLength="30"></asp:textbox></td>
                                           

                                            </tr>
                                        <tr>
                                             <td class="TextField" id ="from1" align="left" runat="server"><asp:Label id="lblfromdt" runat="server" CssClass="TextField" Width="150px"></asp:Label></td>
                                             <td><asp:TextBox ID="txtfromdate" CssClass="btextforbook" runat="server" Height="15px" Width="142px"></asp:TextBox><img src='Images/cal1.gif' id="Img2" onclick='popUpCalendar(this, Form1.txtfromdate, "mm/dd/yyyy")' height="11" width="14" /></td>


                                           

                                              <td class="TextField" id="to1" runat="server" align="left"><asp:Label id="lbltodt" runat="server" CssClass="TextField" Width="149px" ></asp:Label></td>
                                            <td><asp:TextBox ID="txttodate" CssClass="btextforbook" runat="server" Height="16px" Width="143px"></asp:TextBox><img src='Images/cal1.gif' id="Img1" onclick='popUpCalendar(this, Form1.txttodate, "mm/dd/yyyy")' height="11" width="14" /></td></tr>


                                        </tr>
                                   
                                        
                                      


                                        <tr> 
                                             <td class="TextField" id ="bnkslip" align="left" runat="server"><asp:Label id="lblbnkslipdt" runat="server" CssClass="TextField" Width="150px"></asp:Label></td>
                                             <td><asp:TextBox ID="txtbnkslipdt" CssClass="btextforbook" runat="server" Height="15px" Width="141px"></asp:TextBox><img src='Images/cal1.gif' id="Img3" onclick='popUpCalendar(this, Form1.txtbnkslipdt, "mm/dd/yyyy")' height="11" width="14" /></td>

                                           <td align="left"><asp:Label id="lblvchno" runat="server" CssClass="TextField" Width="146px"></asp:Label></td>
											<td align="left"><asp:textbox  id="txtvchno" runat="server" Height="15px" CssClass="btext1" MaxLength="10"></asp:textbox></td>

                                        </tr>
                            <tr>
                                
                                    
                                            <td align="left"><asp:Label id="lblamt" runat="server" CssClass="TextField" Width="149px"></asp:Label></td>
											<td align="left"><asp:textbox  id="txtamt" runat="server" Height="15px" CssClass="btext1" MaxLength="10"></asp:textbox></td>
                                
                            </tr>
                                        <tr align="right">
                                            
                                             <td  style="height: 24px" colspan="6" align="right"><ContentTemplate><asp:button id="btnsubmit" runat="server" CssClass="button1" Text="Submit" Width="92px" ></asp:button></ContentTemplate>
                                            </td>
                                        </tr>

                                        </table>
                         <div id="ExpensesView" style="padding: 0; width: 500px; height: auto; max-height: 240px; margin-left: 10px; margin-top: 10px; border: 2px solid #7DAAE3; overflow: hidden; border-radius: 4px;overflow:auto;border:1px solid gray;">
                </div>
                                    <tr align="right">
                                            
                                             <td  style="height: 24px" colspan="6" align="right"><ContentTemplate><asp:button id="btnsave" runat="server" CssClass="button1" Text="Save" Width="92px" ></asp:button></ContentTemplate>
                                            </td>
                                        </tr>
                          
                        <input id="hiddencomcode" type="hidden" size="5" name="hiddencomcode" runat="server"/>
													<input id="hiddenuserid" type="hidden" size="5" name="hiddenuserid" runat="server"/>
													<input id="Hidden1" type="hidden" name="hiddenagevcode" size="5" runat="server"/>
													<input id="Hidden2" type="hidden" size="1" name="hiddenagensubcode" runat="server"/>
													<input id="hiddenccode" type="hidden" size="1" name="hiddenagensubcode" runat="server"/>
													<input id="hiddenbranchcode" type="hidden" size="1" name="hiddenagensubcode" runat="server"/>
													<input id="hiddendateformat" type="hidden" name="hiddendateformat" runat="server"/>
													<input id="hiddenshow"  type="hidden" size="9" name="hiddenshow" runat="server"/>
													<input id="hiddendelsau"  type="hidden" size="9" name="hiddenshow" runat="server"/>
													<input id="hiddenDup" runat="server" name="hiddendelsau" size="1" type="hidden" />
													<input id="hdempcode" runat="server" name="hiddendelsau" size="1" type="hidden" />
													<input id="hiddenfinancecode" runat="server" name="hiddenfinancecode" size="1" type="hidden" />
													<input id="hiddenoptn" type="hidden" name="hiddenoptn" runat="server"/>
                                                    <input id="hiddencentername" type="hidden" name="hiddencentername" runat="server"/>
												</td>
											</tr>
                			<table id="table6" style="WIDTH: 790px; HEIGHT: 15px" bgColor="#7daae3" cellspacing="0" cellpadding="0" width="634" align="center"  border="0">
													
							<tr>
								<td align="center" ></td>
							</tr>
						</table>
                  </td>
                                </tr>
                            </table>

                                            

    </form>
</body>
</html>
