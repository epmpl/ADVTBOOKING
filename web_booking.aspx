<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="web_booking.aspx.cs" Inherits="web_booking" EnableViewState="false"  %>

<%@ Register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx" %>
<%@ Register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Web Booking</title>     
    <script  language ="javascript"  src="javascript/popupcalender.js" type="text/javascript"></script>
    <script language="javascript" src="javascript/popupcalender_cl.js" type="text/javascript"></script>
    <script language="javascript" src="javascript/Validations.js" type="text/javascript"></script>
    <script language="javascript" src="javascript/webbooking.js" type="text/javascript"></script>
    <script language="javascript" src="javascript/datevalidation.js" type="text/javascript"></script>
    <script language="javascript" src="javascript/jquery-1.5.js" type="text/javascript"></script>


    <script language="javascript" type="text/javascript">
        retexeboth = '<%=ConfigurationManager.AppSettings["retainerexecutiveboth"].ToString() %>'
        regclient = '<%=ConfigurationManager.AppSettings["registerClient"].ToString() %>'
        agnf2 = '<%=ConfigurationManager.AppSettings["agencyf2"].ToString()%>'
        chkforalert = '<%=ConfigurationManager.AppSettings["insertionchk"].ToString()%>';
        clientfromconfig = '<%=ConfigurationManager.AppSettings["CLIENTNAME"].ToString()%>'
        roundoff = '<%=ConfigurationManager.AppSettings["roundoff_Transaction"].ToString()%>'
    </script>




    <link href="css/booking.css" type="text/css" rel="stylesheet" />
</head>
<body  style="margin-left:0px;margin-top:0px;"  onload="blankfields();"  onkeydown="javascript:return tabvalue(event);" onclick="documentClick(event);">
    <form id="Form1" method="post" runat="server" autocomplete="off">
        <div id="Popup" 
        
        style="border: 1px double #000000; position: absolute; top: 0px; left: 0px; display:none; z-index:1; width:350px; height:80px; background-color: #CCFFFF;">
          <div style="background-color: #0099FF"><b><center>
                         <span>Remark</span></center></b></div>
           <div>
           <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
             <td id="tdremark" align="left" class="runtext1" style="font-family: verdana; font-size: 9px;"></td>
            </tr>
           </table>
           
           </div>
         </div>
        <div id="div2" style="position: absolute; top: 0px; left: 0px; border: 0; display:none;z-index:1;" >
            <table cellpadding="0" cellspacing="0" style="border: thin double #000000; height:80px; width:300px; background-color: #D4D0C8;">
                <tr>
                    <td valign="top"><asp:Label ID="lblagaddf2" runat="server" CssClass="TextField" Text="Agency Address"></asp:Label></td>
                    <td valign="top"><asp:TextBox ID="txtagaddf2" Width="180px" Height="50px" runat="server" CssClass="btext1forbooknew" Enabled="true" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                <tr>
                <td colspan="2" valign="top" align="left" style="padding-right:10px"><input type="button" value="Close" runat="server" style="height:18px;" id="close1" class ="buttonsmall"  /></td>
                <td colspan="2" valign="top" align="right" style="padding-right:10px"><input type="button" value="Search" runat="server" style="height:18px;" id="btnagencysearch" class ="buttonsmall"  /></td>
                </tr>
            </table>
        </div>
        <div id="div1" style="position: absolute; top: 0px; left: 0px; border: none; display: none;
            z-index: 1; " >
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:ListBox ID="lstagency" Width="820px" Height="150px" runat="server" CssClass="btextlistagen">
                        </asp:ListBox></td>
                </tr>
            </table>
        </div>
         <div id="divcopyinsertion" style="border: 2px solid rgb(0, 0, 0) ;position: absolute; top: 0px; left: 0px;
            display: none; z-index: 1;">
           
        </div>
         <div id="divreference" style="position: absolute; top: 0px; left: 0px; border: none;
            display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        
                                <asp:ListBox ID="lstreference" Width="300px" Height="65px" runat="server" CssClass="btextlist">
                                </asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
        <div id="divclient" style="position: absolute; top: 0px; left: 0px; border: none;
            display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                       
                                <asp:ListBox ID="lstclient" Width="350px" Height="85px" runat="server" CssClass="btextlistagen">
                                </asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
         <div id="divciragency" style="position: absolute; top: 0px; left: 0px; border: none;
            display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        
                                <asp:ListBox ID="lstciragency" Width="354px" Height="65px" runat="server" CssClass="btextlist">
                                </asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
        <div id="divcirrate" style="position: absolute; top: 0px; left: 0px; border: none;
            display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        
                                <asp:ListBox ID="lstcirrate" Width="354px" Height="65px" runat="server" CssClass="btextlist">
                                </asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
         <div id="divbarter" style="position: absolute; top: 0px; left: 0px; border: none;
            display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        
                                <asp:ListBox ID="lstbarter" Width="354px" Height="65px" runat="server" CssClass="btextlist">
                                </asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
        <div id="divretainer" style="position: absolute; top: 0px; left: 0px; border: none;
            display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                      
                                <asp:ListBox ID="lstretainer" Width="254px" Height="65px" runat="server" CssClass="btextlist">
                                </asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
        <div id="divadcategory" style="position: absolute; top: 0px; left: 0px; border: none;
            display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                       
                                <asp:ListBox ID="lstadcategory" Width="254px" Height="65px" runat="server" CssClass="btextlist">
                                </asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
        <div id="divexec" style="position: absolute; top: 0px; left: 0px; border: none; display: none;
            z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        
                                <asp:ListBox ID="lstexec" Width="254px" Height="65px" runat="server" CssClass="btextlist">
                                </asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
        <div id="divdeal" style="position: absolute; top: 0px; left: 0px; border: none; display: none;
            z-index: +999;">
        </div>
       <div id="divpkg" style="position: absolute; top: 0px; left: 0px; height:90px;width:200px; border:1; display: none; background-color:White;
            z-index: +999;"></div>
        
        
        <table id="OuterTable" cellspacing="0" cellpadding="0" width="1000" align="LEFT"
            border="0">
            <tr valign="top">
                <td colspan="2">
                    <uc1:Topbar ID="Topbar1" runat="server" Text="Web Booking Master"></uc1:Topbar>
                </td>
             
            </tr>
            <tr valign="top">
                <td valign="top" id="sectd">
                    <table class="RightTable" id="RightTable"  border="0"
                        >
                        <tr valign="top">
                            <td>
                               
                                        <asp:ImageButton ID="btnNew" runat="server"  Font-Bold="True" BorderColor="DarkGray"
                                            BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small"  
                                           ></asp:ImageButton><asp:ImageButton ID="btnSave" runat="server" 
                                                Font-Bold="True" BorderColor="DarkGray" BorderStyle="Outset" BackColor="Control"
                                                Font-Size="XX-Small"  AccessKey="s" ></asp:ImageButton><asp:ImageButton
                                                    ID="btnModify" runat="server"  Font-Bold="True" BorderColor="DarkGray"
                                                    BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" >
                                                </asp:ImageButton><asp:ImageButton ID="btnQuery" runat="server"  Font-Bold="True"
                                                    BorderColor="DarkGray" BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small"
                                                     ></asp:ImageButton><asp:ImageButton ID="btnExecute" runat="server"
                                                        Font-Bold="True" BorderColor="DarkGray" BorderStyle="Outset" BackColor="Control"
                                                        Font-Size="XX-Small"  ></asp:ImageButton><asp:ImageButton
                                                            ID="btnCancel" runat="server"  Font-Bold="True" BorderColor="DarkGray"
                                                            BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small" >
                                                        </asp:ImageButton><asp:ImageButton ID="btnfirst" runat="server"  Font-Bold="True"
                                                            BorderColor="DarkGray" BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small"
                                                             ></asp:ImageButton><asp:ImageButton ID="btnprevious" runat="server"
                                                                 Font-Bold="True" BorderColor="DarkGray" BorderStyle="Outset" BackColor="Control"
                                                                Font-Size="XX-Small"  ></asp:ImageButton><asp:ImageButton
                                                                    ID="btnnext" runat="server"  Font-Bold="True" BorderColor="DarkGray"
                                                                    BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small"  >
                                                                </asp:ImageButton><asp:ImageButton ID="btnlast" runat="server"  Font-Bold="True"
                                                                    BorderColor="DarkGray" BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small"
                                                                    ></asp:ImageButton><asp:ImageButton ID="btnDelete" runat="server"
                                                                         Font-Bold="True" BorderColor="DarkGray" BorderStyle="Outset" BackColor="Control"
                                                                        Font-Size="XX-Small" ></asp:ImageButton><asp:ImageButton ID="btnExit" runat="server"
                                                                             Font-Bold="True" BorderColor="DarkGray" BorderStyle="Outset" BackColor="Control"
                                                                            Font-Size="XX-Small"  ></asp:ImageButton>
                                  
                            </td>
                        </tr>
                        <tr><td>
                        <table border="0" cellpadding="0" cellspacing="0" width="100%" style="width:auto;margin:0px -25px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><center><b>Web Booking</b></center></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><asp:Label ID="lblcreationdatetime" runat="server" CssClass="TextField"></asp:Label><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
                   
            </table></td></tr>
            
            <tr><td valign="top">
                        <table style="margin-left:0px;margin-top:-6px;">
                        <tr valign="top">
                        <td style="padding-left:10px"></td>
                        
                            <td>
                            <asp:TextBox ID="txtdatetime" runat="server" CssClass="btext3" style="border-style: solid;border-top-width: 1px; border-right-width: 1px;border-left-width: 1px; border-bottom-width: 1px;" Enabled="false">Date/Time</asp:TextBox>
                                                    </td>
                                                    <td style="width:10px;" valign="top"></td>
                                                    <td valign="top">
                                                        
                                                                <asp:TextBox ID="txtbranch_name" runat="server" CssClass="btext3"  style="border-style: solid;border-top-width: 1px; border-right-width: 1px;border-left-width: 1px; border-bottom-width: 1px;" Enabled="false">Branch</asp:TextBox>
                                                    </td>
                                                     <td style="width:10px;"></td>
                                                    <td>
                                                      
                                                                <asp:TextBox ID="txtbookedby" runat="server" CssClass="btext3"   style="border-style: solid;border-top-width: 1px; border-right-width: 1px;border-left-width: 1px; border-bottom-width: 1px;" Enabled="false">Booked By</asp:TextBox>
                                                    </td>
                                                     <td style="width:10px;"></td>
                                                    <td>
                                                       
                                                                <asp:TextBox ID="txtciobookid" runat="server" style="text-align:left;width:120px;border-style: solid;border-top-width: 1px; border-right-width: 1px;border-left-width: 1px; border-bottom-width: 1px;" CssClass="btext3" Enabled="True">Booking ID</asp:TextBox>
                                                    </td>
                                                    <td style="width:10px;"></td>
                                                    <td>
                                                       
                                                                <asp:TextBox ID="txtprevbook" runat="server" style="text-align:left;width:120px;border-style: solid;border-top-width: 1px; border-right-width: 1px;border-left-width: 1px; border-bottom-width: 1px;" CssClass="btext3" Enabled="false">Pre. Booking ID</asp:TextBox>
                                                    </td>
                                                    
                                                    </tr>
                            </table></td>
                        </tr>
                        
                       
                        <tr>
                            <td id="tbl1">
                                <table align="left" cellpadding="0" cellspacing="0" border="0" width="70%">
                                    <tr>
                                        <td colspan="6" id="tbl2">
                                            <table width="100%" border="0">
                                               
                                                <tr>
                                                    
                                                   
                                                </tr>
                            
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <asp:Label ID="lbagency" runat="server" CssClass="TextField" ></asp:Label></td>
                                        <td valign="top" id="tdagen" colspan="">
                                          
                                                    <asp:TextBox ID="txtagency" runat="server" CssClass="btextforbook" 
                                                        MaxLength="50" onkeyup="javascript:return f2query(event);" 
                                                        ></asp:TextBox><img src='Images/remarks.jpg' id="agremark" height="15" runat="server" width="20" />     
                                              
                                        </td>
                                        <td style="width: 1px">
                                        </td>
                                        <td valign="top" style="width:100px;">
                                            <asp:Label ID="lbclient" runat="server" CssClass="TextField" Text="Client"></asp:Label></td>
                                        <td valign="top">
                                        </td>
                                        <td valign="top" id="tdclient">
                                          
                                                    <asp:TextBox ID="txtclient" runat="server" CssClass="btextforbook" 
                                                        MaxLength="100" onkeyup="javascript:return f2query(event);"></asp:TextBox><img
                                                        src='Images/remarks.jpg' id="clientremark" height="15" width="20" runat="server" />    
                                              
                                        </td>
                                        
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <asp:Label ID="lbaaddress" runat="server" CssClass="TextField" ></asp:Label></td>
                                        <td>
                                            
                                                    <asp:TextBox ID="txtagencyaddress" runat="server" CssClass="btext1forbooknew" TextMode="MultiLine"
                                                       ></asp:TextBox><img
                                                        src='Images/Search.png' id="Imgadvance" onclick='openadvpopup()' runat="server" height="20" width="20" Enabled="False"/>
                                        </td>
                                        <td style="width: 1px">
                                        </td>
                                        <td valign="top">
                                            <asp:Label ID="lbcaddress" runat="server" CssClass="TextField" ></asp:Label></td>
                                        <td valign="top">
                                        </td>
                                        <td>
                                          
                                                    <asp:TextBox ID="txtclientadd" runat="server" CssClass="btext1forbooknew" TextMode="MultiLine"
                                                        MaxLength="500"></asp:TextBox>
                                                         
                                        <asp:Button Text="Rg" runat="server" ID="regclient"  style="height:18px;width:30px; text-align:left" 
                                                 Font-Size="X-Small" Enabled="false"/></td>
                                       
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <asp:Label ID="lbagescode" runat="server" CssClass="TextField" ></asp:Label></td>
                                        <td valign="top">
                                         
                                                    <asp:DropDownList ID="drpagscode" runat="server" CssClass="dropdownforbook" 
                                                         >
                                                    </asp:DropDownList>
                                        </td>
                                        <td style="width: 1px">
                                        </td>
                                        <td style="display:none" valign="top">                                           
                                                    <asp:TextBox ID="txtagencytype" runat="server" CssClass="btextforbook" Enabled="False"></asp:TextBox>                                             
                                        </td>
                                        <td  valign="top">
                                            <asp:Label ID="lblmobile" runat="server" CssClass="TextField" ></asp:Label></td>
                                       
                                     
                                           <td  valign="top">
                                           
                                                    &nbsp;</td>
                                                    
                                                    <td >
                                          
                                                    <asp:TextBox ID="txtmobile" runat="server" CssClass="btextforbook" 
                                                        MaxLength="40"></asp:TextBox>
                                             
                                        </td>
                                        
                                        
                                        
                                        
                                        
                                          
                                      
                                        
                                    </tr>
                                   
                                    <tr>
                                        <td valign="top">
                                            <asp:Label ID="lblagencystatus" runat="server" CssClass="TextField" ></asp:Label></td>
                                        <td valign="top">
                                          
                                                    <asp:TextBox ID="txtagencystatus" ReadOnly="true" runat="server" CssClass="btextforbook" Enabled="false"
></asp:TextBox>
                                        </td>
                                        <td style="width: 1px">
                                        </td>
                                        <td valign="top">
                                            <asp:Label ID="lblagencypaymode" runat="server" CssClass="TextField" ></asp:Label></td>
                                        <td valign="top">
                                        </td>
                                        <td valign="top">
                                           <asp:DropDownList ID="txtagencypaymode" runat="server" CssClass="dropdownforbook" Enabled="false">
                                                </asp:DropDownList>
                                                
                                        </td>
                                        
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <asp:Label ID="lblagencycreditperiod" runat="server" CssClass="TextField" ></asp:Label></td>
                                        <td valign="top">
                                           
                                                    <asp:TextBox ID="txtcreditperiod" runat="server" CssClass="btextforbooktd" Enabled="False"></asp:TextBox>
                                                    <asp:Label ID="lbltd" runat="server" CssClass="TextField">TD</asp:Label>
                                                    <asp:TextBox ID="txttd" runat="server" CssClass="btextforbooktd" Enabled="False"></asp:TextBox>
                                        </td>
                                        <td style="width: 1px">
                                        </td>
                                        <td valign="top">
                                            <asp:Label ID="lbrono" runat="server" CssClass="TextField" ></asp:Label></td>
                                        <td valign="top">
                                        </td>
                                        <td valign="top">
                                          
                                                    <asp:TextBox ID="txtrono" runat="server" CssClass="btextforbook" 
                                                    
                                                        MaxLength="40" onblur="javascript:return checkro();"></asp:TextBox>
                                             
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <asp:Label ID="lbrodate" runat="server" CssClass="TextField" ></asp:Label></td>
                                        <td valign="top">
                                          
                                                    <asp:TextBox ID="txtrodate" runat="server" CssClass="btextforbook"
                                                    ></asp:TextBox><img
                                                        src='Images/cal1.gif' id="Img2" onclick='popUpCalendar(this, Form1.txtrodate, "mm/dd/yyyy")'
                                                        height="11" width="14" />
                                        </td>
                                        <td style="width: 1px">
                                        </td>
                                        <td valign="top">
                                            <asp:Label ID="lbrostatus" runat="server" CssClass="TextField" ></asp:Label></td>
                                        <td valign="top">
                                        </td>
                                        <td valign="top">
                                           
                                                    <asp:DropDownList ID="drprostatus" runat="server" CssClass="dropdownforbook" >
                                                    </asp:DropDownList>
                                        </td>
                                        
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <asp:Label ID="lbdockit" runat="server" CssClass="TextField" ></asp:Label></td>
                                        <td valign="top">
                                           
                                                    <asp:TextBox ID="txtdockitno1" runat="server" CssClass="btextforbook" 
                                                    ></asp:TextBox>
                                        </td>
                                        <td style="width: 1px">
                                        </td>
                                        <td valign="top">
                                            <asp:Label ID="lbkey" runat="server" CssClass="TextField"></asp:Label></td>
                                        <td valign="top">
                                        </td>
                                        <td valign="top">
                                           
                                                    <asp:TextBox ID="txtkeyno" runat="server" CssClass="btextforbook" 
                                                        MaxLength="50"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <asp:Label ID="lbececname" runat="server" CssClass="TextField" ></asp:Label></td>
                                        <td valign="top" id="tdexec">
                                          
                                                    <asp:TextBox ID="txtexecname" runat="server"  CssClass="btextforbook" MaxLength="50"></asp:TextBox><input type="button" value="M" runat="server" style="height:18px;width:20px;color:red" id="Button1" class ="buttonsmall" Enabled="False" />
                                              
                                        </td>
                                        <td style="width: 1px">
                                        </td>
                                        <td valign="top">
                                            <asp:Label ID="lbexeczone" style="width:180px;" runat="server"  CssClass="TextField"></asp:Label></td>
                                        <td valign="top">
                                        </td>
                                        <td valign="top">
                                           
                                                    <asp:TextBox ID="txtexeczone" runat="server" CssClass="btextforbook" 
                                                        ></asp:TextBox>
                                        </td>
                                        
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                                <asp:Label ID="lblagencyoutstand" runat="server" CssClass="TextField" ></asp:Label></td>
                                        <td colspan="2" valign="top">
                                              
                                                        <asp:TextBox ID="txtagencyoutstand" runat="server" CssClass="btextforbook" 
                                                        
                                                            MaxLength="50" Enabled="false"></asp:TextBox>
                                        </td>
                                        <td >
                                            <asp:Label ID="lblretainer" runat="server" CssClass="TextField" ></asp:Label></td>
                                        </td>
                                        <td valign="top">
                                        </td>
                                        <td valign="top" id="tdretainer">
                                           
                                                    <asp:TextBox ID="drpretainer" runat="server" CssClass="btextforbook" 
                                                    Enabled="true" MaxLength="50" onkeyup="javascript:return f2query(event);"></asp:TextBox>
                                              
                                        </td>
                                        
                                        
                                    </tr>
                                    
                                    <!--ageny-->
                                    </table>
                                    </td></tr>
                                    
                                </table>
                                
                                
                                <table>
          
            
            <tr>
                <td colspan="5" valign="top">
                    <div style="display: block" id="divpopup">
                        <table border="1" id="tdpck" cellpadding="0" cellspacing="0" width="540px ">
                            <tr>
                                <td bgcolor="#7daae3">
                                   
                                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btnlink"></asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton5" runat="server" CssClass="btnlink" ></asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btnlink"></asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton4" runat="server" CssClass="btnlink"></asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton3" runat="server" CssClass="btnlink"></asp:LinkButton>
                                     <%--       <asp:LinkButton ID="LinkButton6" runat="server" CssClass="btnlink"></asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton7" runat="server" CssClass="btnlink"></asp:LinkButton>--%>
                                               <asp:ImageButton ID="attachment1" runat="server" CssClass="btnlinkImage" ToolTip="Attachment" ImageUrl="~/Images/index.jpeg" Enabled="false" ></asp:ImageButton>
                                            <asp:ImageButton ID="attachment2" runat="server" CssClass="btnlinkImage" ToolTip="Other Attachment" ImageUrl="~/Images/index.jpeg"  Enabled="false"></asp:ImageButton>
                                            
                                       
                                </td>
                                <td align="right" bgcolor="#7daae3"><asp:LinkButton ID="hidehref" runat="server"  CssClass="btnlinkhide"></asp:LinkButton></td>
                            </tr>
                            <tr>
                                <td colspan="5" >
                                    <table width=" 100% " cellpadding="0" cellspacing="0" border="0">
                                        <tr>
                                            <td>
                                                <table id="tblpackage" width=" 100% " style="display: none" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td valign="top">
                                                <asp:Label ID="lbcurrency" runat="server" CssClass="TextField" Text=""></asp:Label></td>
                                                        <td valign="top">
                                               
                                                        <asp:DropDownList ID="drpcurrency" runat="server" CssClass="dropdownforbooksmall" Enabled="True"
                                                           >
                                                        </asp:DropDownList>
                                                        </td>
                                                        <td></td>
                                                        <td width="100">
                                                         <asp:Label ID="lbladon" runat="server" CssClass="TextField" Text=""></asp:Label>
                                                       
                                                         <asp:CheckBox ID="chkadon" runat="server" CssClass="TextField"  />   
                                                        </td>
                                                         <td valign="top">
                                                            &nbsp;</td>
                                                        <td valign="top" >
                                                            <asp:Label ID="lbreference" runat="server" style="display:none;" CssClass="TextField" Text="Reference Id"></asp:Label></td>
                                                        <td valign="top" id="tdref" style="display:none;">
                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%"><tr><td>
                                                        <asp:TextBox ID="txtreference" runat="server" style="text-align:left;" CssClass="btextforbookrightsmall" 
                                                            Enabled="False" MaxLength="50"></asp:TextBox><input ID="btnrefid" type="button" value="Ref" runat="server"  class="buttonsmall" style="width:25px;" Enabled="false" />   
                                                        </td></tr></table>
                                                        </td>
                                                       
                                                        <td valign="top">
                                                        </td>
                                                    <tr>
                                                        <td valign="top">
                                                            <asp:Label ID="lbpackage" runat="server" CssClass="TextField" Text=""></asp:Label></td>
                                                        <td valign="top">
                                                           
                                                                    <asp:ListBox ID="drppackage" runat="server" SelectionMode="Multiple" CssClass="btextlistpacksmall" Width="120px"></asp:ListBox>
                                                              
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                           
                                                                    <asp:Button ID="btncopy" runat="server" CssClass="buttcopy123" Text=">>>"  OnClick="btncopy_Click" Enabled="True" />
                                                                <asp:Button ID="btndel" runat="server" CssClass="buttcopy123" Text="<<<"  OnClick="btncopy_Click" Enabled="True" /></td>
                                                        <td>
                                                           
                                                                    <asp:ListBox ID="drppackagecopy" runat="server" CssClass="btextlistpacksmall" Width="120px"></asp:ListBox>
                                                              
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            <asp:Label ID="lbselectdate" runat="server" CssClass="TextField" Text=""></asp:Label></td>
                                                        <td valign="top">
                                                            
                                                                    <asp:TextBox ID="txtdummydate" runat="server" CssClass="btextforbooksmall" onkeypress="return dateenter(event);" ></asp:TextBox><img
                                                                        src='Images/cal1.gif' id="Img3" onclick='popUpCalendar(this, Form1.txtdummydate, "mm/dd/yyyy")'
                                                                        onfocus="abc()" height="11" width="14" />
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lbad" runat="server" CssClass="TextField" Text=""></asp:Label></td>
                                                        <td>
                                                           
                                                                    <asp:CheckBox ID="chktfn" runat="server" CssClass="TextField" />&nbsp;
                                                               
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top" style="text-align:left;" align="left" Width="125px" >
                                                            <asp:Label ID="lbnoofins" runat="server"   CssClass="TextField" Text="No. Of Insertion"></asp:Label></td>
                                                        <td valign="top">
                                                           
                                                                    <asp:TextBox ID="txtinsertion" onkeypress="return notchar2(event);" MaxLength="6" runat="server"
                                                                        CssClass="btextforbookrightsmall" AutoPostBack="True" 
                                                                        Enabled="True"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td  >
                                                            <asp:Label ID="lbrepdate" runat="server" CssClass="TextField"></asp:Label></td>
                                                        <td >
                                                           
                                                                    <asp:TextBox ID="txtrepeatingdate" onkeypress="return notchar2(event);" MaxLength="4"
                                                                        CssClass="btextforbookrightsmall" runat="server"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            <asp:Label ID="lbpaid" runat="server" CssClass="TextField" Text=""></asp:Label></td>
                                                        <td valign="top">
                                                           
                                                                    <asp:TextBox ID="txtpaid" runat="server" AutoPostBack="True" CssClass="btextforbookrightsmall"
                                                                        Enabled="False" MaxLength="10" ></asp:TextBox>
                                                               
                                                        </td>
                                                        <td>
                                                        </td>
                                                         <td style="display:none;" id="lbrevtd" runat="server">
                                                            <asp:Label ID="lblrevisedate" runat="server" CssClass="TextField" Text="Revise Date"></asp:Label></td>
                                                        <td style="display:none;"  id="txtrevtd" runat="server"><asp:TextBox ID="txtrevisedate" runat="server" CssClass="btextforbooksmall" onkeypress="return dateenter(event);"></asp:TextBox><img
                                                        src='Images/cal1.gif' id="Img4" onclick='popUpCalendar(this, Form1.txtrevisedate, "mm/dd/yyyy")'
                                                        onfocus="abc()" height="11" width="14" /></td>   
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr> 
                                                    <td valign="top">
                                                        <asp:Label ID="lbrptcurrency" runat="server" CssClass="TextField" Text=""></asp:Label></td>
                                                        <td valign="top">
                                                
                                                        <asp:DropDownList ID="drprptcurrency" runat="server" CssClass="dropdownforbooksmall" Enabled="True">
                                                        </asp:DropDownList>
                                                        </td>
                                                        <td valign="top">
                                                           </td>
                                                        <td valign="top">
                                                        </td>
                                                        <td>
                                                        </td>
                                                                                                                
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            <asp:Label ID="lbcontractname" runat="server" CssClass="TextField" Text=""></asp:Label></td>
                                                        <td valign="top">
                                                            
                                                                    <asp:TextBox ID="txtcontractname" runat="server" AutoPostBack="True" CssClass="btextforbookrightsmall"
                                                                        Enabled="False" MaxLength="10" ></asp:TextBox>
                                                                    <asp:CheckBox ID="chkcontract" runat="server" CssClass="TextField" />
                                                                
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lbcontracttype" runat="server" CssClass="TextField" Text=""></asp:Label></td>
                                                        <td>
                                                           
                                                                    <asp:TextBox ID="txtcontracttype" runat="server" AutoPostBack="True" CssClass="btextforbookrightsmall"
                                                                        Enabled="False" MaxLength="10" ></asp:TextBox>
                                                               
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                <asp:Label ID="lbprintremark" runat="server" Text="" CssClass="TextField"></asp:Label></td>
                                                        <td colspan="4" valign="top">
                                              
                                                        <asp:TextBox ID="txtprintremark" runat="server" CssClass="btextcapaddsmall" TextMode="MultiLine" style="text-transform:uppercase"
                                                            Enabled="True" MaxLength="500"></asp:TextBox><asp:Button ID="btndeal" runat="server" CssClass="buttonsmall" text="" Enabled="False" />
                                                        </td>
                                                       
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td id="tdpaid">
                                                        </td>
                                                    </tr>
                                                </table>
                                               </td></tr>
                                               
                                    </table>
                                 
                                    
                                    <table id="addetails" style="display: none" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbadtype" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>
                                               
                                                        <asp:DropDownList ID="drpbooktype" runat="server" style="width:100px" CssClass="dropdownforbook" Enabled="True">
                                                        </asp:DropDownList><input type="button" value="R" Enabled="False" runat="server" style="height:18px;width:20px;color:red" id="btnfmg" class ="buttonsmall"  />
                                            </td>
                                            <td style="padding-left:47px;"></td>
                                           
                                           <td>
                                                <asp:Label ID="lbadcat" runat="server" CssClass="TextField" Text=""></asp:Label></td>
                                            <td>
                                               
                                                        <asp:TextBox ID="txtcategory" runat="server" CssClass="btextforbook" MaxLength="50"></asp:TextBox>
                                                    
                                            </td>
                                            
                                           
                                        </tr>
                                        <tr>
                                        
                                         <td>
                                                <asp:Label ID="lbadcat3" runat="server" CssClass="TextField" Text=""> </asp:Label></td>
                                            <td>
                                               
                                                        <asp:TextBox ID="txtappby" runat="server" CssClass="btextforbook" MaxLength="50" Enabled="false"></asp:TextBox>
                                                   
                                            </td>
                                            
                                            
                                         <td style="padding-left:47px;"></td>
                                        
                                          <td>
                                                <asp:Label ID="Label4" runat="server" CssClass="TextField" Text=""> </asp:Label></td>
                                            <td>
                                               
                                                        <asp:TextBox ID="txtaudit" runat="server" CssClass="btextforbook" MaxLength="50" Enabled="false"></asp:TextBox>
                                                   
                                            </td>
                                        
                                           
                                           
                                            
                                           
                                           
                                        </tr>
                                        <tr>
                                        
                                        
                                         <td>
                                                        <asp:Label ID="Label2" runat="server" CssClass="TextField" Text="Product"></asp:Label></td>
                                            <td >
                                                      
                                                               
                                                           <asp:DropDownList ID="drpuom" runat="server" CssClass="dropdownforbook" AutoPostBack="false"
                                                            Enabled="true"  >
                                                           
                                                        </asp:DropDownList>
                                            </td>
                                       <td style="padding-left:105px;"></td>
                                       <td>
                                                        <asp:Label ID="lbproduct" runat="server" CssClass="TextField" Text=""></asp:Label></td>
                                            <td >
                                                      
                                                                
                                                           <asp:DropDownList ID="drpmatsta" runat="server" CssClass="dropdownforbook" AutoPostBack="false"
                                                            Enabled="True">
                                                             <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                                                <asp:ListItem  Value="hardcopy">Hard Copy</asp:ListItem>
                                                                <asp:ListItem  Value="softcopy">Soft Copy</asp:ListItem>
                                                                <asp:ListItem  Value="cd">CD</asp:ListItem>
                                                                <asp:ListItem  Value="asonmatter">As on Matter</asp:ListItem>
																<asp:ListItem  Value="compose">Compose</asp:ListItem>
                                                                <asp:ListItem  Value="redesign">Re-design</asp:ListItem>
                                                                <asp:ListItem  Value="other">Others</asp:ListItem>
                                                            
                                                        </asp:DropDownList>
                                            </td>
                                        
                                           
                                            
                                            
                                        </tr>
                            
                                       
                                       
                                        
                                    </table>
                                      
                                    <table id="tblbill" style="display: none;" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblbillcycle" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>
                                               
                                                        <asp:DropDownList ID="drpbillcycle" runat="server" CssClass="dropdownforbook" Enabled="False">
                                                        </asp:DropDownList>
                                                
                                            </td>
                                            <td>
                                                <asp:Label ID="lblrevenuecenter" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>
                                               
                                                        <asp:DropDownList ID="drprevenue" runat="server" CssClass="dropdownforbook" Enabled="False">
                                                        </asp:DropDownList>
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblpaymenttype" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>
                                              
                                                        <asp:DropDownList ID="drppaymenttype" runat="server" CssClass="dropdownforbook" Enabled="False">
                                                        </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbbillstatus" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>
                                               
                                                        <asp:DropDownList ID="drpbillstatus" runat="server" CssClass="dropdownforbook" Enabled="False">
                                                        </asp:DropDownList>
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                          <tr id="cashrecvd"  style="display:none">
                                            <td > 
                                       <asp:Label ID="Label3" runat="server" CssClass="TextField" Text="Cash Discount" ></asp:Label></td>
                                       <td id="Td2"  onkeypress="return notchar2(event);" runat="server"  ><asp:TextBox ID="txtcashdiscount" runat="server" CssClass="btextforbookright">
                                         </asp:TextBox></td>
                                       <td id="Td1" runat="server" > 
                                       <asp:Label ID="lblcashrecieved" runat="server" CssClass="TextField" ></asp:Label></td>
                                       <td  runat="server"  ><asp:TextBox ID="drpcashrecieved" onkeypress="return notchar2(event);" runat="server" CssClass="btextforbookright">
                                         </asp:TextBox></td>
                                         
                                 </tr>
                                         <tr>
                                            <td id="tdcarname" style="display:none" valign="top">
                                                <asp:Label ID="lbcardname"  runat="server" CssClass="TextField"></asp:Label></td>
                                            <td align="left" valign="top" id="tdtxtcarname" style="display:none">
                                                <asp:TextBox ID="txtcardname"  runat="server" CssClass="btextforbook"></asp:TextBox>
                                            </td>
                                            <td id="tdtype" style="display:none" valign="top">
                                                <asp:Label ID="lbtype"  runat="server" CssClass="TextField"></asp:Label></td>
                                            <td id="tddrptyp" style="display:none">
                                                <asp:DropDownList ID="drptype"  runat="server" CssClass="dropdownforbook"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td id="tdexdat" style="display:none" valign="top">
                                                <asp:Label ID="lbexdate"  runat="server" CssClass="TextField"></asp:Label></td>
                                            <td align="left" valign="top" id="tdtxtexdat" style="display:none; ">
                                                <asp:DropDownList ID="drpmonth" runat="server" CssClass="drpsmall">
                                                <asp:ListItem Selected="True" Value="0">Month</asp:ListItem>
                                                <asp:ListItem  Value="1">Jan</asp:ListItem>
                                                <asp:ListItem  Value="2">Feb</asp:ListItem>
                                                <asp:ListItem  Value="3">Mar</asp:ListItem>
                                                <asp:ListItem  Value="4">Apr</asp:ListItem>
                                                <asp:ListItem  Value="5">May</asp:ListItem>
                                                <asp:ListItem  Value="6">Jun</asp:ListItem>
                                                <asp:ListItem  Value="7">Jul</asp:ListItem>
                                                <asp:ListItem  Value="8">Aug</asp:ListItem>
                                                <asp:ListItem  Value="9">Sep</asp:ListItem>
                                                <asp:ListItem  Value="10">Oct</asp:ListItem>
                                                <asp:ListItem  Value="11">Nov</asp:ListItem>
                                                <asp:ListItem  Value="12">Dec</asp:ListItem>
                                                </asp:DropDownList><asp:DropDownList ID="drpyear" runat="server" CssClass="drpsmall">
                                                <asp:ListItem Selected="true" Value="0">Year</asp:ListItem>
                                                <asp:ListItem  Value="2008">08</asp:ListItem>
                                                <asp:ListItem  Value="2009">09</asp:ListItem>
                                                <asp:ListItem  Value="2010">10</asp:ListItem>
                                                <asp:ListItem  Value="2011">11</asp:ListItem>
                                                <asp:ListItem  Value="2012">12</asp:ListItem>
                                                <asp:ListItem Value="2013">13</asp:ListItem>
                                                <asp:ListItem Value="2014">14</asp:ListItem>
                                                <asp:ListItem Value="2015">15</asp:ListItem>
                                                <asp:ListItem Value="2016">16</asp:ListItem>
                                                <asp:ListItem Value="2017">17</asp:ListItem>
                                                <asp:ListItem Value="2018">18</asp:ListItem>
                                                <asp:ListItem Value="2019">19</asp:ListItem>
                                                <asp:ListItem Value="2020">20</asp:ListItem>
                                                <asp:ListItem  Value="2021">21</asp:ListItem>
                                                <asp:ListItem  Value="2022">22</asp:ListItem>
                                                <asp:ListItem Value="2023">23</asp:ListItem>
                                                <asp:ListItem Value="2024">24</asp:ListItem>
                                                <asp:ListItem Value="2025">25</asp:ListItem>
                                                <asp:ListItem Value="2026">26</asp:ListItem>
                                                <asp:ListItem Value="2027">27</asp:ListItem>
                                                <asp:ListItem Value="2028">28</asp:ListItem>
                                                <asp:ListItem Value="2029">29</asp:ListItem>
                                                <asp:ListItem Value="2030">30</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td id="tdcardno" style="display:none" valign="top">
                                                <asp:Label ID="lbcardno"  runat="server" CssClass="TextField"></asp:Label></td>
                                            <td id="tdtxtcarno" style="display:none"  valign="top">
                                            <asp:TextBox ID="txtcardno"  runat="server" onkeypress="return rateenter(event)" MaxLength="20" CssClass="btextforbookright"></asp:TextBox>
                                            </td>
                                        </tr>
                                          <tr>
                                    <td id="tdchqno" runat="server" style="display:none">
                                        <asp:Label ID="lbchqno"  runat="server" CssClass="TextField"></asp:Label></td>
                                    <td id="tdtextchqno" runat="server" style="display:none">
                                        <asp:TextBox ID="ttextchqno" MaxLength="20"  runat="server" CssClass="btextforbook" onkeypress="return rateenter(event)"></asp:TextBox></td>
                                    <td id="tdchqamt" runat="server" style="display:none">
                                        <asp:Label ID="lbchqamt"  runat="server" CssClass="TextField"></asp:Label></td>
                                    <td align="left" valign="top" id="tdtextchqamt" style="display:none">                        
                                        <asp:TextBox ID="ttextchqamt"  runat="server" CssClass="btextforbook" onkeypress="return rateenter(event)"></asp:TextBox></td>
                                  </tr>
                                  <tr>
                                    <td id="tdchqdate" style="display:none">
                                        <asp:Label ID="lbchqdate"  runat="server" CssClass="TextField"></asp:Label></td>
                                    <td id="tdtextchqdate" style="display:none">
                                        <asp:TextBox ID="ttextchqdate"  runat="server" CssClass="btextforbook"></asp:TextBox></td>
                                    <td id="tdbankname" style="display:none"> 
                                        <asp:Label ID="lbbankname"  runat="server" CssClass="TextField"></asp:Label></td>
                                    <td id="tdtextbankname" style="display:none">                    
                                        <asp:TextBox ID="ttextbankname"  runat="server" CssClass="btextforbook"></asp:TextBox></td>
                                    <td></td>
                                 </tr>
                                    <tr>  <td id="tdourbank" style="display:none">
                                        <asp:Label ID="lbourbank"  runat="server" Text="Our Bank" CssClass="TextField"></asp:Label></td>
                                       <td id="tdtextourbank" style="display:none">
                                         <asp:DropDownList ID="drpourbank"  runat="server" CssClass="dropdownforbook"></asp:DropDownList></td>
                                 </tr>
                                        
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblbillsize" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td valign="top" align="left">
                                                <asp:TextBox ID="txtbillheight" CssClass="btextsmallsizerig" runat="server" Enabled="False"
                                                            MaxLength="4"></asp:TextBox>&nbsp;&nbsp;*&nbsp;&nbsp;
                                                        <asp:TextBox ID="txtbillwidth" CssClass="btextsmallsizerig" runat="server" Enabled="False"
                                                            MaxLength="4"></asp:TextBox>
                                                      
                                                        <asp:Label ID="lbbilluom" runat="server" CssClass="TextFielduom"></asp:Label>
                                                   
                                            </td>
                                            <td>
                                                <asp:Label ID="lblbillto" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>
                                              
                                                        <asp:DropDownList ID="drpbillto" runat="server" CssClass="dropdownforbook" Enabled="False">
                                                        </asp:DropDownList>
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td id="tdrec" style="display:none">
                                                <asp:Label ID="lbreceipt" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td align="left" valign="top" id="receipt" style="display:none">
                                               
                                                        <asp:TextBox ID="txtreceipt" runat="server" CssClass="btextforbookright" Enabled="False"
                                                            MaxLength="4" onkeypress="return notchar2(event);"></asp:TextBox>
                                                   
                                            </td>
                                            <td><asp:Label ID="lbbillamtlocal" runat="server" CssClass="TextField" Text="Local Curr. Bill Amt"></asp:Label></td>
                                            <td> <asp:TextBox ID="txtbillamt" runat="server" CssClass="btextforbookright" Enabled="False"
                                                            onkeypress="return notchar2(event);"></asp:TextBox>
                                            <span id="print" style="display:none">
                                                <asp:Label ID="lbprint" runat="server"  CssClass="TextFieldprint"></asp:Label></td>
                                            
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbltradedisc" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>
                                             
                                                        <asp:TextBox ID="txttradedisc" onkeypress="return notchar2(event);" runat="server" CssClass="btextsmallsizerig"
                                                            Enabled="False"></asp:TextBox>
                                                             <input CssClass="TextField" type="checkbox" ID=chktrade onclick="blankGross();" disabled=disabled />
                                            </td>
                                            <td>
                                                <asp:Label ID="lbbillamt" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>
                                                
                                                        <asp:TextBox ID="txtbillamtlocal" runat="server" CssClass="btextforbookright" Enabled="False"
                                                            onkeypress="return notchar2(event);"></asp:TextBox>
                                                  
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr id="billhold" runat="server">
                                            <td>
                                                <asp:Label ID="lblholdbill" runat="server" Text="Hold Billing" CssClass="TextField"></asp:Label></td>
                                            <td colspan="4">                                                
                                                        <input CssClass="TextField" type="checkbox" ID=chkholdbill disabled=disabled />
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr  style="display:none">
                                            <td>
                                                <asp:Label ID="lblclientcatdisc" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="txtclientcatdisc" runat="server" CssClass="btextforbook" Enabled="False"
                                                             MaxLength="500"></asp:TextBox></td>                                            
                                            <td>
                                                <asp:Label ID="lblclientcatamt" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="txtclientcatam" runat="server" CssClass="btextforbook" Enabled="False"
                                                             MaxLength="500"></asp:TextBox></td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr  style="display:none">
                                            <td>
                                                <asp:Label ID="lblflatfreqdisc" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="txtflatfreqdisc" runat="server" CssClass="btextforbook" Enabled="False"
                                                             MaxLength="500"></asp:TextBox></td>                                            
                                            <td>
                                                <asp:Label ID="lblflatfreqamt" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="txtflatfreqamt" runat="server" CssClass="btextforbook" Enabled="False"
                                                             MaxLength="500"></asp:TextBox></td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr  style="display:none">
                                            <td>
                                                <asp:Label ID="lblcatdisc" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="txtcatdisc" runat="server" CssClass="btextforbook" Enabled="False"
                                                             MaxLength="500"></asp:TextBox></td>                                            
                                            <td>
                                                <asp:Label ID="lblcatamt" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="txtcatamt" runat="server" CssClass="btextforbook" Enabled="False"
                                                             MaxLength="500"></asp:TextBox></td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbbillremark" runat="server" Text="Bill Remark" CssClass="TextField"></asp:Label></td>
                                            <td colspan="4">
                                              
                                                        <asp:TextBox ID="txtbillremark" runat="server" CssClass="btextcapadd" TextMode="MultiLine"
                                                            Enabled="False" MaxLength="500"></asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                    
                                    <table id="pagedetail" style="display: none;" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblpage" runat="server" CssClass="TextField" Text="">&nbsp;</asp:Label></td>
                                            <td>
                                              
                                                        <asp:DropDownList ID="drppageprem" runat="server" CssClass="dropdownforbook"
                                                            Enabled="True">
                                                        </asp:DropDownList>
                                            </td>
                                            
                                            <td style="padding-left:80px;"></td>
                                            
                                             <td>
                                                <asp:Label ID="lblposit" runat="server" CssClass="TextField" Text="">&nbsp;</asp:Label></td>
                                            <td>
                                              
                                                        <asp:DropDownList ID="drpposition" runat="server" CssClass="dropdownforbook"
                                                            Enabled="True">
                                                        </asp:DropDownList>
                                            </td>
                                           
                                        </tr>
                                       
                                       
                                          
                                            
                                           <tr>
                                            <td>
                                          
                                                <asp:Label ID="lbltotarea" runat="server" CssClass="TextField" Text=hdnlabel.Value></asp:Label>
                                             
                                                
                                                </td>
                                            <td>
                                               
                                                        <asp:TextBox ID="txttotalarea" onkeypress="return notchar2Area();" runat="server" CssClass="btextforbookright"
                                                            Enabled="True" MaxLength="8"></asp:TextBox>
                                                        <asp:Label ID="lbmeasuretotal" runat="server" CssClass="TextFielduom"></asp:Label>
                                                 
                                            </td>
                                        </tr>
                                    </table>
                                    <table id="tblrate" style="display: none" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbscheme" runat="server" CssClass="TextField" Text=""></asp:Label></td>
                                            <td>
                                             
                                                        <asp:TextBox ID="drpscheme" runat="server" CssClass="btextforbookrightsmall" Enabled="True"></asp:TextBox>
                                                   
                                            </td>
                                              <td style="padding-left:65px;">
                                            </td>
                                            <td>
                                                <asp:Label ID="lbratecode" runat="server" CssClass="TextField" Text=""></asp:Label></td>
                                            <td>
                                             
                                                        <asp:DropDownList ID="txtratecode" runat="server" CssClass="dropdownforbooksmall" Enabled="True">
                                                        </asp:DropDownList>
                                                 
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblcardrate" runat="server" CssClass="TextField"></asp:Label>
                                            </td>
                                            <td>
                                             
                                                        <asp:TextBox ID="txtcardrate" CssClass="btextforbookrightsmall" runat="server" Enabled="True"></asp:TextBox>
                                            </td>
                                              <td>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblcardamt" runat="server" CssClass="TextField"></asp:Label>
                                            </td>
                                            <td>
                                              
                                                        <asp:TextBox ID="txtcardamt" CssClass="btextforbookrightsmall" runat="server" Enabled="True"></asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbdealtype" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>
                                               
                                                        <asp:TextBox ID="txtdealrate" runat="server" CssClass="btextforbookrightsmall" Enabled="True"></asp:TextBox>
                                                   
                                            </td>
                                              <td>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbdeviation" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>
                                               
                                                        <asp:TextBox ID="txtdeviation" runat="server" CssClass="btextforbookrightsmall" Enabled="True"></asp:TextBox>
                                                   
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbagreed" runat="server" CssClass="TextField" Text="Agreed Rate"></asp:Label>
                                            </td>
                                            <td>
                                               
                                                        <asp:TextBox ID="txtagreedrate" onpaste="return True;" CssClass="btextforbookrightsmall" onkeypress="return notchar2(event);" runat="server" Enabled="True"
                                                            MaxLength="10"></asp:TextBox>
                                            </td>
                                              <td>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbagreamo" runat="server" CssClass="TextField" Text="Agreed Amount"></asp:Label>
                                            </td>
                                            <td>
                                              
                                                        <asp:TextBox ID="txtagreedamt" onpaste="return false;" onkeypress="return notchar2(event);" CssClass="btextforbookrightsmall" runat="server" Enabled="True"
                                                            MaxLength="10"></asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbldiscount" runat="server" CssClass="TextField"></asp:Label>
                                            </td>
                                            <td>
                                                
                                                        <asp:TextBox ID="txtdiscount" CssClass="btextforbookrightsmall" runat="server" Enabled="True"></asp:TextBox>
                                            </td>
                                              <td>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbldiscpre" runat="server" CssClass="TextField"></asp:Label>
                                            </td>
                                            <td>
                                               
                                                        <asp:TextBox ID="txtdiscpre" CssClass="btextforbookrightsmall" runat="server" Enabled="True"></asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                         <tr id="translationdisc" runat="server" >
                                              <td>
                                                <asp:Label ID="lbltranslationdisc" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>
                                              
                                                        <asp:TextBox ID="txttranslationdisc" runat="server" CssClass="btextforbookrightsmall" Enabled="True"
                                                            onkeypress="return notchar2(event);"></asp:TextBox>
                                                    
                                            </td>
                                            <td>
                                            </td>
                                             <td>
                                                <asp:Label ID="lblpospremdisc" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>
                                              
                                                        <asp:TextBox ID="txtpospremdisc" runat="server" CssClass="btextforbookrightsmall" Enabled="True"
                                                            onkeypress="return notchar2(event);"></asp:TextBox>
                                                    
                                            </td>
                                             </tr>
                                          <tr>
                                            <td>
                                                <asp:Label ID="lbspecialamo" runat="server" CssClass="TextField" Text="Special Discount"></asp:Label>
                                            </td>
                                            <td>
                                                
                                                        <asp:TextBox ID="txtspedisc" CssClass="btextforbookrightsmall" onkeypress="return rateenter(event);" runat="server" Enabled="True"
                                                            MaxLength="10"></asp:TextBox>
                                            </td>
                                              <td>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbspediscper" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>
                                                
                                                        <asp:TextBox ID="txtspediscper" runat="server" onkeypress="return rateenter(event);" CssClass="btextforbookrightsmall" Enabled="True"
                                                            MaxLength="10"></asp:TextBox>
                                                    
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbspace" runat="server" CssClass="TextField" Text=""></asp:Label></td>
                                            <td>
                                                
                                                        <asp:TextBox ID="txtspacedisc"  CssClass="btextforbookrightsmall" runat="server" Enabled="True"
                                                            MaxLength="10"></asp:TextBox>
                                                
                                            </td>
                                              <td>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbspadiscper" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>
                                                
                                                        <asp:TextBox ID="txtspadiscper" onkeypress="return rateenter(event);" runat="server" CssClass="btextforbookrightsmall" Enabled="True"
                                                            MaxLength="10"></asp:TextBox>
                                                                       
                                                
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbpagepostamt" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>
                                               
                                                        <asp:TextBox ID="txtpageamt" runat="server" CssClass="btextforbookrightsmall" Enabled="True"></asp:TextBox>
                                                    
                                            </td>
                                              <td>
                                            </td>
                                           <td>
                                            <div id="addagency" runat="server">
                                             <asp:Label ID="lblagencyaddcomm" runat="server" CssClass="TextField" Text=""></asp:Label></div>
                                                </td>
                                            <td>
                                           <div id="addagencycomm" runat="server">
                                             
                                                        <asp:TextBox ID="txtaddagencycommrate" CssClass="btextforbookrightsmall_comm" style="width:30px" onkeypress="return notchar2_book(event,this);" runat="server" Enabled="True"
                                                            MaxLength="10"></asp:TextBox><font class="TextField">%</font><asp:TextBox ID="txtaddagencycommrateamt" CssClass="btextforbookrightsmall_comm" onkeypress="return notchar2_book(event,this);"  runat="server" Enabled="True"
                                                            MaxLength="10"></asp:TextBox></div>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td>
                                                <asp:Label ID="lbspechar" runat="server" CssClass="TextField" Text=""></asp:Label></td>
                                            <td>
                                               
                                                        <asp:TextBox ID="txtextracharges" onkeypress="return notchar2(event);" CssClass="btextforbookrightsmall" runat="server" Enabled="True"
                                                            MaxLength="10"></asp:TextBox>
                                            </td>
                                            <!-- put text box for retainer comm>-->
                                            <td></td>
                                            <td>
                                                <asp:Label ID="lblRetainercomm" runat="server" CssClass="TextField" Text=""></asp:Label></td>
                                            <td>
                                              
                                                        <asp:TextBox ID="txtRetainercomm" CssClass="btextforbookrightsmall_comm" style="width:30px" runat="server" Enabled="True"
                                                            MaxLength="10" onkeypress="return notchar2_book(event);"></asp:TextBox><font class="TextField">%</font><asp:TextBox ID="txtRetainercommamt" CssClass="btextforbookrightsmall_comm" onkeypress="return notchar2_book(event);" runat="server" Enabled="True"
                                                            MaxLength="10"></asp:TextBox></td>
                                            <!--end of box>-->
                                         </tr>
                                        <tr>
                                            <td valign="top">
                                                <asp:Label ID="lbgrossamt" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td>
                                            
                                                        <asp:TextBox ID="txtgrossamtlocal" runat="server" CssClass="btextforbookrightsmall" Enabled="True"></asp:TextBox>
                                                
                                                &nbsp;</td>
                                              <td>
                                            </td>
                                            <td><asp:Label ID="lbllocalcurr" runat="server" CssClass="TextField" Text=""></asp:Label></td>
                                            <td><asp:TextBox ID="txtgrossamt" runat="server" CssClass="btextforbookrightsmall" Enabled="True"></asp:TextBox></td>
                                            <td valign="top">
                                            
                                                        <asp:Button ID="btnshgrid" runat="server" CssClass="buttonsmall" Text="Get Rate" Enabled="True" />
                                                         
                                                        </td>
                                            
                                        </tr>
                                       
                                    </table>
                                    
                                    <table id="tbbox" style="display: none" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbboxcode" runat="server" CssClass="TextField" Text="Box Code"></asp:Label></td>
                                            <td valign="top">
                                              
                                                        <asp:DropDownList ID="drpboxcode" runat="server" CssClass="dropdownforbook" Enabled="True"
                                                           >
                                                        </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbboxno" runat="server" CssClass="TextField" Text="Box No."></asp:Label></td>
                                            <td>
                                            </td>
                                            <td>
                                              
                                                        <asp:TextBox ID="txtboxno" runat="server" Enabled="True" CssClass="btextforbook" ></asp:TextBox>
                                               
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td colspan="2">
                                              
                                                        <asp:CheckBox ID="chkage" Text="same as Agency" runat="server" CssClass="TextField" />
                                                        <asp:CheckBox ID="chkclie" Text="same as Client" runat="server" CssClass="TextField" />
                                                   
                                            
                                                <asp:Label ID="lblcancelcharges" runat="server" CssClass="TextField" Text="Cancle Charges"></asp:Label>
                                            
                                                <input CssClass="TextField" type="checkbox" ID="chkcanclecharges" onclick="blankGross();" disabled="disabled" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbboxadd" runat="server" CssClass="TextField" Text="Box Address"></asp:Label></td>
                                            <td colspan="4">
                                               
                                                        <asp:TextBox ID="txtboxaddress"  MaxLength="500" runat="server"
                                                            CssClass="btextcapadd"  Enabled="True"
                                                            TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                     <table id="tbvts" style="display: none" border="0" cellpadding="0" cellspacing="0">
                                      <tr>
                                     <td>
                                                <asp:Label ID="lblciragency" runat="server" CssClass="TextField" Text="Circulation Agency"></asp:Label></td>
                                            <td valign="top" colspan="4">
                                                
                                                        <asp:TextBox ID="txtciragency" runat="server" CssClass="btextadtype" Enabled="True"
                                                        MaxLength="50"></asp:TextBox>     
                                                
                                            </td>
                                    </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblvts" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td valign="top">
                                               
                                                        <asp:TextBox ID="txtvts"  runat="server" CssClass="btextforbookright"
                                                            Enabled="True" MaxLength="4"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblinvoice" runat="server" CssClass="TextField"></asp:Label></td>
                                          
                                            <td>
                                               
                                                        <asp:TextBox ID="txtinvoice" runat="server" CssClass="btextforbookright" Enabled="True"
                                                             MaxLength="4"></asp:TextBox>&nbsp;
                                                   
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                          
                                            <td>
                                                <asp:Label ID="lblciredition" runat="server" Text="Edition" CssClass="TextField"></asp:Label></td>
                                            
                                            <td>
                                                
                                                        <asp:TextBox ID="txtciredition" runat="server" CssClass="btextforbookright" Enabled="True"
></asp:TextBox>&nbsp;
                                                    
                                            </td>
                                              <td>
                                                <asp:Label ID="lblcirrate" runat="server" CssClass="TextField" Text="Rate"></asp:Label></td>
                                            <td valign="top">
                                                
                                                        <asp:TextBox ID="txtcirrate"   runat="server" CssClass="btextforbookright"   
                                                            Enabled="True"></asp:TextBox>
                                                
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblbilladdress" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td colspan="4">
                                               
                                                        <asp:TextBox ID="txtbilladdress" TextMode="multiLine" runat="server" CssClass="btextadtype"
                                                            Enabled="True"></asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                     </td>
                                    </tr>
                                    </table>

                     </div></td></tr></table>
        <table cellp
                                
                                
                                
                     

                     </div> </td> </tr>  </table>
                      <table cellpadding="0" cellspacing="0">
            <tr>
                <td align="left" id="tblinsert" runat="server">
                </td>
            </tr>
        </table>
        <div id="showselectedition" style=" z-index:0;background-color:#e1e1e1;border-right: thin groove; border-top: thin groove; border-left: thin groove; border-bottom: thin groove;font-size: 8pt;position:absolute;display:none;height:100px;width:109px;top:200px;left:100px;"></div>
                     
                      <table cellpadding="0" cellspacing="0"><tr><td>
        <input id="hiddencompcode" type="hidden" size="1" name="hiddencompcode" runat="server" />        
        <input id="hiddenuserid" type="hidden" size="1" name="hiddenuserid" runat="server" />
        <input id="hdnagency" type="hidden" size="1" name="hdnagency" runat="server" />
        <input id="hiddenagency" type="hidden" size="1" name="hiddenagency" runat="server" />
        <input id="hiddensavemod" type="hidden" size="1" name="hiddensavemod" runat="server" />
        <input id="hndalert1" type="hidden" size="1" name="hndalert1" runat="server" />
        <input id="hiddendateformat" type="hidden" size="1" name="hiddendateformat" runat="server" />
        <input id="hndagalert1" type="hidden" size="1" name="hndagalert1" runat="server" />
        <input id="hiddencashrecieved" type="hidden" size="1" name="hiddencashrecieved" runat="server" />
        <input id="hiddenagcommflag" type="hidden" size="1" name="hiddenagcommflag" runat="server" />
        <input id="hiddentradedisc" type="hidden" size="1" name="hiddentradedisc" runat="server" />
        <input id="hdndefpayment" type="hidden" size="1" name="hdndefpayment" runat="server" />
        <input id="hiddenpay" type="hidden" size="1" name="hiddenpay" runat="server" />
        <input id="hiddenbillpay" type="hidden" size="1" name="hiddenbillpay" runat="server" />
        <input id="hiddenbillto" type="hidden" size="1" name="hiddenbillto" runat="server" />
        <input id="hiddenstatus" type="hidden" size="1" name="hiddenstatus" runat="server" />
        <input id="hiddockit" type="hidden" size="1" name="hiddockit" runat="server" />
        <input type="hidden" id="tempinsert" runat="server" />
        <input type="hidden" id="hiddencalendar" runat="server" />
        <input id="hiddenpackage" type="hidden" runat="server" />
        <input id="hiddeninserts" type="hidden" size="1" name="inserts" runat="server" />
        <input type="hidden" id="hiddenrowcount" runat="server" />
        <input type="hidden" id="hiddisceditgrid" runat="server" />
        <input type="hidden" id="hiddenuomdesc" runat="server" />
        <input type="hidden" id="hdncategory" runat="server" />
        <input type="hidden" id="hiddenclickdate" runat="server" />
        <input type="hidden" id="hiddeninsertion" runat="server" />
        <input type="hidden" id="hiddenzone" runat="server" />
        <input type="hidden" id="hidlineedit" runat="server" />
        <input type="hidden" id="hdnfollodate" runat="server" />
        <input type="hidden" id="allowpaidchangeper" runat="server" value="Y" />
        <input type="hidden" id="configclient" runat="server" />
        <input type="hidden" id="hiddenregClient" runat="server" />
        <input type="hidden" id="hiddeninsertwise" runat="server" />
        <input type="hidden" id="hiddenuserdisc" runat="server" />
        <input type="hidden" id="hiddenschemetype" runat="server" />
        <input type="hidden" id="hiddenvaliddate" runat="server" />
        <input type="hidden" id="hiddenrostatus" runat="server" />
        <input type="hidden" id="hiddencioidformat" runat="server" />
        <input type="hidden" id="hidcash" runat="server" />
        <input type="hidden" id="hiddencenter" runat="server" />
        <input type="hidden" id="dateformat" runat="server" />
        <input type="hidden" id="hidpremedit" runat="server" />
        <input type="hidden" id="hiddenratecheckdate" runat="server" />
        <input type="hidden" id="hiddenratepremtype" runat="server" />
        <input type="hidden" id="hiddenusername" runat="server" />
        <input type="hidden" id="hiddentfn" runat="server" />
        <input type="hidden" id="hiddencurrency" runat="server" />
        <input type="hidden" id="hidcurr" runat="server" />
        <input type="hidden" id="hiddenpremtype" runat="server" />
        <input type="hidden" id="hiddentype" runat="server" />
        <input type="hidden" id="hiddenprefix" runat="server" />
        <input type="hidden" id="hiddensufix" runat="server" />
        <input type="hidden" id="hiddenvat" runat="server" />
        <input type="hidden" id="hiddencirculation" runat="server" />
        <input type="hidden" id="hiddenprereceipt" runat="server" />
        <input type="hidden" id="hiddenauditsession" runat="server" />
        <input type="hidden" id="agncomm_seq_com" runat="server" />
        <input type="hidden" id="hidschememin" runat="server" />
        <input type="hidden" id="hdnrevise" runat="server" />
        <input type="hidden" id="hiddenconnect" runat="server" />
        <input type="hidden" id="allowprem_card_disc_rate" runat="server" value="C" />
        <input type="hidden" id="retcomm" runat="server" />
        <input type="hidden" id="retcommtype" runat="server" />
        <input id="hiddenafency_retainer" runat="server" type="hidden" name="hiddenadscat5" />
        <input type="hidden" id="hiddentranalpremtype" runat="server" />
        <input type="hidden" id="hidshareman" runat="server" />
        <input type="hidden" id="hiddensepcashier" runat="server" />
        <input type="hidden" id="hidcurrency_convrate" runat="server" />
        <input type="hidden" id="hiddenbillamt" runat="server" />
        <input type="hidden" id="hiddenrateauditflag" runat="server" />
        <input type="hidden" id="hiddenquotation" runat="server"/>
        <input type="hidden" id="hiddenbarteramt" runat="server" />
        <input type="hidden" id="hiddenstopbarterbooking" runat="server" />
        <input type="hidden" id="hiddencirpub" runat="server" />
        <input type="hidden" id="hiddenciredi" runat="server" />
        <input id="hiddenprevamt" type="hidden" size="1" name="inserts" runat="server" />
        <input type="hidden" id="hiddenprint_rec" runat="server" />
        <input id="hiddenreceiptno" type="hidden" size="1" name="inserts" runat="server" />
        <input type="hidden" id="hiddenboxchrgtype" runat="server" />
        <input type="hidden" id="hiddenaddAgencyComm" runat="server" /> 
        <input type="hidden" id="hiddenbuttonidcheck" runat="server" />
        <input id="hiddenroperm" type="hidden" size="1" name="inserts" runat="server" />
        <input type="hidden" id="hiddencutofftime" runat="server" />
        <input type="hidden" id="currdate" runat="server" />
        <input type="hidden" id="ena_adsubcataftbill" runat="server"/>
        <input type="hidden" id="hdnregclient" runat="server"/>
        <input type="hidden" runat="server" id="hidbackdatereceipt" />
        <input type="hidden" id="hiddeneiitagcomm" runat="server" />
        <input type="hidden" id="hiddencancelcharge"  runat="server" />
        <input type="hidden" id="hiddenuom" runat="server" /> 
        <input type="hidden" id="hiddenclientname" runat="server" />
        <input id="hiddenaudit" type="hidden" size="1" name="inserts" runat="server" />
        <input id="hiddensubcode" type="hidden" runat="server" />
        <input type="hidden" id="hidattach1" runat="server" />
        <input type="hidden" id="hidattach2" runat="server" />
        <input id="hiddencioid" type="hidden" size="1" name="inserts" runat="server" />
        <input type="hidden" id="Hdnmodbook" runat="server"/>
        <input type="hidden" id="hiddencopybooking" runat="server" />
        <input id="hiddenbrand" type="hidden" runat="server" />
        <input id="hiddencattype" type="hidden" size="1" name="inserts" runat="server" />&nbsp;
        <input type="hidden" id="hiddencashdiscper" runat="server" />
        <input type="hidden" id="hiddenadtype" runat="server" />
        <input id="hiddenbackdatebook" type="hidden" size="1" name="Hidden2" runat="server" />
        <input type="hidden" id="hdnlabel" runat="server" />
        <input type="hidden" id="hdnfilename" runat="server" />
        <input type="hidden" id="hdnrowcount" runat="server" />
        <input type="hidden" id="hiddenrateauditpreferrence" runat="server" />
        <input type="hidden" id="hdneditionforgeo" runat="server" />
        <input type="hidden" id="Hiddenbillclear" runat="server" />
        <input type="hidden" id="hiddenmodifyinsert" runat="server" />
        <input type="hidden" id="creditreceipt_allow" runat="server" />
        <input type="hidden" id="hdnrevenue" runat="server" />
        <input type="hidden" id="txtdesignation" runat="server" />
        <input type="hidden" id="hdnvts" runat="server"/> 
        <input id="hdnclientcatdistype" type="hidden" runat="server" />
        <input id="hdnflatfreqdisctype" type="hidden" runat="server" />
        <input id="hdncatdisctype" type="hidden" runat="server" />                                                       
        </table>
    </form>
</body>
</html>