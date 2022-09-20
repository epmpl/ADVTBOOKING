<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Executive_team_transfer.aspx.cs" Inherits="Executive_team_transfer" EnableEventValidation="false" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
                    <head>
                        <title>EXECUTIVE TEAM MASTER</title>
                        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
                        <meta content="C#" name="CODE_LANGUAGE"/>
                        <meta content="JavaScript" name="vs_defaultClientScript"/>
                        <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
                        <script type="text/javascript" language="javascript" src="javascript/Executive_team_transfer.JS"></script>
                        <script type="text/javascript" language="javascript" src="javascript/tree.js"></script>
                        <script type="text/javascript" language="javascript" src="javascript/Validations.js"></script>
                        <script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
                        <script type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
                        <link href="css/main.css" type="text/css" rel="stylesheet"/>
                    </head>
	
<body  topmargin="0" leftmargin="0" style="background-color:#f3f6fd; margin: 0px 0px 0px 0px;" >
                    <form id="Form1" method="post" runat="server">
                    <div id="divcity" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lstcity" Width="480px" Height="85px" runat="server" CssClass="dropdown" ></asp:ListBox></td></tr></table></div>
                    <div id="divcomp" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lstcomp" Width="480px" Height="85px" runat="server" CssClass="dropdown" ></asp:ListBox></td></tr></table></div>
                    <div id="divbank" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lstbank" Width="480px" Height="85px" runat="server" CssClass="dropdown" ></asp:ListBox></td></tr></table></div>
                    <table id="OuterTable" cellspacing="0" cellpadding="0" width="1000" border="0">
                    <tr valign="top">
                    <td colspan="2"><uc1:topbar id="Topbar1" runat="server" text="Box Master"></uc1:topbar></td>
                    </tr>
                    <tr valign="top" >
                    <td valign="top" style="width: 184px"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
                    <td valign="top" style="width: 796px">
                    <table class="RightTable" runat="server"  id="RightTable" cellspacing="0" cellpadding="0" border="0" >
                   <%-- <tr valign="top">
                    <td style="padding-left:-1px">

                    <asp:ImageButton id="btnNew" runat="server" Font-Size="XX-Small"
                    BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnSave" runat="server"  Font-Size="XX-Small" BackColor="Control"
                    BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnModify" runat="server"  Font-Size="XX-Small" BackColor="Control"
                    BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnQuery" runat="server"  Font-Size="XX-Small" BackColor="Control"
                    BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnExecute" runat="server" Font-Size="XX-Small"
                    BackColor="Control" BorderStyle="Outset"    BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnCancel" runat="server"  Font-Size="XX-Small" BackColor="Control"
                    BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnfirst"  runat="server"  Font-Size="XX-Small" BackColor="Control"
                    BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"></asp:ImageButton><asp:ImageButton id="btnprevious" runat="server" Font-Size="XX-Small"
                    BackColor="Control" BorderStyle="Outset"    BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnnext" runat="server"  Font-Size="XX-Small" BackColor="Control"
                    BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnlast" runat="server"  Font-Size="XX-Small" BackColor="Control"
                    BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnDelete" runat="server"  Font-Size="XX-Small" BackColor="Control"
                    BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton><asp:ImageButton id="btnExit" runat="server"  Font-Size="XX-Small" BackColor="Control"
                    BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" ></asp:ImageButton>
                    </td>

                    </tr>--%>


                    </table>
                    </td>
                    </tr>
                    </table>


      <div id="div3" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
      <table cellpadding="0" cellspacing="0"style="margin:0px 0px;"><tr><td>
      <asp:ListBox ID="lstexecutive" Width="350px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox>
      </td></tr></table></div>
                    
      <div id="divteam" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
      <table cellpadding="0" cellspacing="0"style="margin:0px 0px;"><tr><td>
      <asp:ListBox ID="lstteamname" Width="350px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox>
      </td></tr></table></div>      
                    
                    
                    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="width:auto;margin:15px 40px;">
                        <tr>
                        <td style="width:27px;"></td>
                        <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                        <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Executive Team Transfer</center></b></td>
                        <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
                        <td style="width:730px"><table cellpadding="0" cellspacing="0">
                        <tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                        </tr>
                    </table>

                    <table  cellspacing="0" cellpadding="0" style="width:529px; margin:30px 300px; height: 126px;"> 
                            
                        <tr>
                        <td colspan="2" ><asp:label id="lblexname" runat="server" CssClass="TextField"></asp:label></td>
                        <td width="400px"><asp:TextBox ID="tctexeretname" CssClass="btext1_new" runat="server"></asp:TextBox></td>
                        </tr>
                   
                        <tr>
                        <td colspan="2"><asp:label id="lblteamname" runat="server" CssClass="TextField"></asp:label></td>
                        <td width="400px"><asp:TextBox ID="txtteamname" runat="server" CssClass="btext1_new"></asp:TextBox></td>
                        </tr>

                        <tr align="right">
                        <td>
                        <asp:button id="btntransfer" runat="server" Height="24px" Font-Bold="True" BorderStyle="Outset" BackColor="Control" Font-Size="X-Small" Width="100px"  CssClass="topbutton" Text="TRANSFER"></asp:button> 
                        </td>
                        </tr>          
	                
	                 </table>           
	                 
                   
                    

                    <input id="hiddencomcode" runat="server" name="hiddencomcode" type="hidden" />
                    <input id="hiddencompcode" runat="server" name="hiddencompcode" style="width: 55px" type="hidden"/>
                    <input id="hiddenuserid" runat="server" style="width: 48px" type="hidden" />
                    <input id="hiddendateformat" runat="server" style="width: 77px" type="hidden" />
                    <input id="hdnexecode" type="hidden" size="1" name="hdnexecode" runat="server"/>
                    <input id="hdnteamcode" type="hidden" size="1" name="hdnteamcode" runat="server"/>
                    
</form>
</body>

</html>
