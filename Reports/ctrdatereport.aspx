<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ctrdatereport.aspx.cs" Inherits="Reports_ctrdatereport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Category Date wise Report</title>
     <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1" />
    <meta name="CODE_LANGUAGE" content="C#" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <style type="text/css">.style1 { FONT-WEIGHT: bold; COLOR: #ffffff; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif }
	    .style2 { COLOR: #ffffff }
		</style>
    <link href="css/main.css" type="text/css" rel="stylesheet" />
    <link href="css/booking.css" type="text/css" rel="stylesheet" />
    <link href="css/report.css" type="text/css" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />

    <script type="text/javascript" language="javascript" src="javascript/datevalidation.js"></script>

    <script type="text/javascript" language="javascript" src="javascript/popupcalender.js"></script>

    <script type="text/javascript" language="javascript" src="javascript/entertotab.js"></script>

    <script type="text/javascript" language="javascript" src="javascript/ctrdatereport.js"></script>

   
    <style type="text/css">.style1 { FONT-WEIGHT: bold; FONT-SIZE: xx-large; COLOR: #ffffff }
	.style2 { COLOR: #ffffff }
	.style4 { FONT-WEIGHT: normal; FONT-SIZE: 14pt; COLOR: #d85414; FONT-FAMILY: Verdana }
	.style6 { FONT-SIZE: x-small }
	.style7 { FONT-WEIGHT: bold; COLOR: #6666ff }
		</style>

    <script language="javascript" type="text/javascript">
		function forfocus()
		{
		document.getElementById('Txtusernme').focus();
		}
		function maximize()
        {
        window.moveTo(0,0)            
        window.resizeTo(screen.availWidth, screen.availHeight)
         }
        maximize();
    </script>
</head>
<body onload="document.getElementById('txtfromdate').focus();" onkeydown="javascript:return tabvaluectrepo(event);" onkeypress="eventcalling(event)">
    <form id="form2" runat="server">
    <div id="divdistrict" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
    <table cellpadding="0" cellspacing="0">
    <tr><td>
    <asp:ListBox ID="lstdistrict" Width="280px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox>
    </td></tr>
    </table>
    </div>
    
        <table width="1005" border="0" cellspacing="0" cellpadding="0" align="center" style="width: 1005px;
            height: 358px">
            <tr>
                <td width="100%">
                    <img src="images/img_02A.jpg" alt="" width="1004" border="0" />
                  
                </td>
            </tr>
            <tr>
                   <td id="td2" onclick="javascript:return logoutpage();" width="100%" 
                    style="background-image: url('images/top.jpg'); font-family: Trebuchet MS; font-size: 13px;
                    color: #CC0000; cursor: hand;" align="right">
                    Logout</td>
            </tr>
            <tr>
                <td style="height: 505px">
                    <table width="985" border="0" cellspacing="0" cellpadding="0" style="width: 985px;
                        height: 486px">
                        <tr>
                            <!---------left bar start--------->
                            <td width="100%" style="width: 200px">
                                <img src="images/leftbar.jpg"  alt="" style="width: 193px; height: 483px" height="483" width="193" /></td>
                            <!---------left bar end--------->
                            <!---------middle start--------->
                            <td valign="top" style="width: 78%">
                                <table cellpadding="0" cellspacing="0" width="790" style="width: 790px; height: 488px"
                                    border="1">
                                   <tr>
                                        <td align="center">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="heading" runat="server" CssClass="heading"></asp:Label></td>
                                                </tr>
                                            </table>
                                            <br />
                                            <table width="0" border="0" cellspacing="0" cellpadding="2">
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="fromdate" runat="server" CssClass="TextField"></asp:Label></td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtfromdate" runat="server" CssClass="btext1bill"></asp:TextBox>
                                                        <img src='Images/cal1.gif' onclick='popUpCalendar(this, form2.txtfromdate, "mm/dd/yyyy")' onfocus="abc();" height="14" width="14"/>
                                                        
                                                             
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="todate" runat="server" CssClass="TextField"></asp:Label></td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txttodate" runat="server" CssClass="btext1bill"></asp:TextBox>
                                                        <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form2.txttodate, "mm/dd/yyyy")'onfocus="abc();" height="14" width="14"/>
                                                          
                                                            
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lblprtcent" runat="server" CssClass="TextField"></asp:Label></td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="dpprintcenter" runat="server" CssClass="dropdown">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                  <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lbl_branch" runat="server" CssClass="TextField"></asp:Label></td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="dpbranch" runat="server" CssClass="dropdown">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                
<tr>
        <td align="left"><asp:Label id="lbPublication" runat="server" CssClass="TextField"></asp:Label></td>
        <td  align="left">
      
            <asp:DropDownList id="dppub1" runat="server" CssClass="dropdown" ></asp:DropDownList>
         
        </td>
        </tr>



<tr>
        <td align="left">
        <asp:Label id="lbEdition" runat="server" CssClass="TextField"></asp:Label></td>
        <td  align="left">
       
            <asp:DropDownList id="dpedition" runat="server" CssClass="dropdown"></asp:DropDownList>
       
        </td></tr>
                                                   <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lbldistrict" runat="server" CssClass="TextField"></asp:Label></td>
                                                    <td align="left">
                                                 <asp:TextBox ID="txtdistrict" runat="server" CssClass="btext1bill"></asp:TextBox>
                                                   
                                                     
                                                   
                                                    </td>
                                                </tr>
                                                <tr>
														<td align="left"><asp:Label id="lbteam" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                           
                                                                    <asp:DropDownList id="dpteam" runat="server" CssClass="dropdown"  ></asp:DropDownList>
                                                                     
                                                        </td>
                                                        
                                                        
                                                      
                                                       
                                                           
                                                      
                                                       
                                                       <tr>
                                                            <td align="left">
                                                        <asp:Label id="lbexec" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                         
                                                                    <asp:DropDownList id="dpexec" runat="server" CssClass="dropdown" type="password"></asp:DropDownList>
                                                              
                                                        </td></tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lbadtype" runat="server" CssClass="TextField"></asp:Label></td>
                                                    <td align="left">
                                                        <asp:DropDownList CssClass="dropdown" ID="dpadtype" runat="server">
                                                           
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lbadcat1" runat="server" CssClass="TextField"></asp:Label></td>
                                                    <td align="left">
                                                        <asp:DropDownList CssClass="dropdown" ID="dpadcat" runat="server">
                                                           
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lbladcat2" runat="server" CssClass="TextField"></asp:Label></td>
                                                    <td align="left">
                                                        <asp:DropDownList CssClass="dropdown" ID="dpadsubcat" runat="server">
                                                            
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lbladcat3" runat="server" CssClass="TextField"></asp:Label></td>
                                                    <td align="left">
                                                        <asp:DropDownList CssClass="dropdown" ID="dpadsubcat3" runat="server">
                                                           
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                              
                                             
                                               
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="lbdestination" runat="server" CssClass="TextField"></asp:Label></td>
                                                    <td align="left">
                                                        <asp:DropDownList ID="Txtdest" runat="server" CssClass="dropdown" type="password">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                               
                                        </table>
                                            <table>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Button ID="BtnRun" runat="server" Width="90px"  ></asp:Button>
                                                    </td>
                                                    <td align="right">
                                                        <asp:Button ID="Btnexit" runat="server" Width="90px"  ></asp:Button>
                                                    </td>
                                                </tr>
                                            </table>
                                            
                                                        </table>
                                    </tr>
                                </table>
                            </td>
                             <!---------middle end--------->
                        </tr>
                    </table>
                    
                      	<input id="HDN_dateformat" type="hidden" name="HDN_dateformat" runat="server" />
                        <input id="hiddenuseid" type="hidden" name="hiddenuseid" runat="server" />
                        <input id="hiddencompcode" type="hidden" name="hiddencompcode" runat="server" />
                        <input id="hiddpadtype" type="hidden" name="hiddpadtype" runat="server" />
                        <input id="hiddendateformat" name="hiddendateformat" runat="server" type="hidden" />
                        <input id="hdncompcode" name="hidden" runat="server" type="hidden" />
                        <input id="hdnadcat" name="hdnadcat" runat="server" type="hidden" />
                        <input id="hdnadsubcat" name="hdnadsubcat" runat="server" type="hidden" />
                        <input id="hdnadsubcat3" name="dpadsubcat3" runat="server" type="hidden" />
                        <input id="hdnadsubcat4" name="adsubcat4" runat="server" type="hidden" />
                        <input id="hdnadsubcat5" name="adsubcat5" runat="server" type="hidden" />
                        <input id="dateformat" runat="server" type="hidden" name="dateformat" />
                        <input id="hdnunitcode" runat="server" type="hidden" name="hdnunitcode" />
                        <input id="hdnbranch" runat="server" type="hidden" name="dpbranch" />
                        <input id="hdndistrict" runat="server" type="hidden" name="dpdistrict" />
                        <input id="hdnTxtdest" runat="server" type="hidden" name="Txtdest" />
                        <input id="hdnprintcenter" runat="server" type="hidden" name="dpprintcenter" />
                        <input id="hidden_dist_text" runat="server" type="hidden" />
                         <input id="hiddenexecutive" type="hidden" name="hiddenexecutive" runat="server" />
                       <input id="hiddenexecutivename" type="hidden" name="hiddenexecutivename" runat="server" />
                      <input id="hidden_dist" runat="server" type="hidden" />
                       <input id="hiddenuserid" type="hidden" name="hiddenuserid" runat="server" />
                       <input id="hdnteam" type="hidden" name="hdnteam" runat="server" />
                        <input id="hiddenpubname" type="hidden" name="hiddenpubname" runat="server" />
                         <input id="hiddenediname" type="hidden" name="hiddenediname" runat="server" />
      
    
    </form>
</body>
</html>
