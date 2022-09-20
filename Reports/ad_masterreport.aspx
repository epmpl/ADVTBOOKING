<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ad_masterreport.aspx.cs" Inherits="Reports_ad_masterreport" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Circulation Master Report</title>
    
  
    <script language="javascript" src="javascript/ad_masterreport.js"></script>
    <script language="javascript" src="javascript/popupcalender.js"></script>
     <script language="javascript" src="javascript/prototype.js"></script>
    <link href="css/topbar.css" type="text/css" rel="stylesheet"/>
    <link href="css/main_cir.css" type="text/css" rel="stylesheet"/>
    
    <style type="text/css">
        .style1
        {
            width: 217px;
        }
        .style2
        {
            width: 138px;
        }
        .style3
        {
            width: 137px;
        }
        .style4
        {
            width: 44px;
        }
        .style6
        {
            width: 65px;
        }
        .style9
        {
            width: 208px;
        }
        .style10
        {
            width: 290px;
        }
        .style11
        {
            width: 212px;
        }
        .style14
        {
            width: 103%;
        }
        .style15
        {
            cursor: hand;
            width: 103%;
        }
    </style>
    
</head>
<body onload="javascript:return blankfields();" onkeydown="javascript:return bindtabvalue_fpc(event);" onkeypress ="javascript:return chkfield(event)" style="margin:0px 0px;">
    <form id="form1" runat="server">
    <div>
    <%--<div id="divchannel_fpc" style="position: absolute; top: 0px; left: 0px; border: none;display: none; z-index: 1;"><table cellpadding="0" cellspacing="0"><tr><td style="border-bottom:solid 1px gray; border-left:solid 1px gray; border-right:solid 1px gray; border-top:solid 1px gray;"><asp:ListBox ID="lstchannel_fpc" Width="150px" Height="65px" runat="server" CssClass="btextlist"></asp:ListBox></td></tr></table></div>--%>
    <div id="divunit" style="position: absolute; top: 0px; left: 0px; border: none;display: none; z-index: 1;"><table cellpadding="0" cellspacing="0"><tr><td style="border-bottom:solid 1px gray; border-left:solid 1px gray; border-right:solid 1px gray; border-top:solid 1px gray;"><asp:ListBox ID="lstunit" Width="250px" Height="90px" runat="server" CssClass="btextlist" ></asp:ListBox></td></tr></table></div>
    <div>
    <div id="divreport" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1;"><table cellpadding="0" cellspacing="0"><tr><td style="border-bottom:solid 1px gray; border-left:solid 1px gray; border-right:solid 1px gray; border-top:solid 1px gray;"><asp:ListBox ID="lstreport" Width="250px" Height="65px" runat="server" CssClass="btextlist"></asp:ListBox></td></tr></table></div>
  <%--  <table>
          <tr>
              <td valign="top">--%>
  <table id="OuterTable" cellspacing="0" cellpadding="0"  border="0" style="margin-left:5%;">
				<tr>
					<td bordercolor="#1" class="style14"><img src="images/img_02A.jpg" border="0" 
                            style="width: 743px" />
                     
                    </td>
				</tr>
                <tr>
					<%--<td width="100%" bordercolor="#1"><img src="images/top.jpg" width="1004" border="0" /></td>--%>
					<td  id="td2"  onclick="javascript:return logoutpage();" bordercolor="#1" 
                        style="background-image:url('images/top.jpg');font-family:Trebuchet MS;font-size: 13px;color:#CC0000;" 
                        align="right" class="style15">
                     Logout</td>
				</tr>
    </table> 
    <%--<table id="OuterTable" cellspacing="0" cellpadding="0" width="1000" border="0">
           <tr valign="top">
			  <td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="DEAL AUDIT"></uc1:topbar></td>
		  </tr>
    </table>--%>
           <%--   </td>
          </tr>
    </table>--%>
    </div>
    </div>
    
      <table style="height:24px; width: 100%;margin-left:5%;"><tr valign="top">
  
						
                           <td><asp:Label ID="lblunit" runat="server" CssClass="TextField"></asp:Label>
                          <%-- </td>
                            <td>  --%>                          
                            <asp:TextBox ID="txtunit" runat="server" CssClass="btext1"></asp:TextBox>
                            
                          <%--  </td> <td>--%>
                                                <asp:label id="Reports" runat="server" CssClass="TextField" ></asp:label>
                                               <%-- </td>
											<td >--%>
                                                <asp:TextBox ID="txtReports" runat="server"  CssClass="btext1" 
                                                    AutoPostBack="false"   ></asp:TextBox>
                                                   <%-- </td>
                                                  
                                                    <td>--%>
                                                    <asp:Label ID="type" runat="server" CssClass="TextField" ></asp:Label>
                                                    <%--</td>
                                                    <td>--%>
                                                    <asp:DropDownList ID="drtype" runat="server" CssClass="btext1"  Width="145px" Height="23px">                                                        
                                                     </asp:DropDownList></td>
                                                    
                                                    </tr>
                                                    
                                                    
    
    </table>
    
    
      <table border='1' style="margin-left:5%;"><tr><td class="style9" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Select the view fields</td>
    <td>&nbsp;</td>
    <td style=" margin-left :40px " class="style1" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Select the filters   
    </td><td class="style3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;From</td>
        <td class="style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;To</td></tr></table>
        
        <table>
        
        <tr> <div id="div3" style="position: absolute; top: 0px; left: 0px; border: none;display: none; z-index: 1;">
        <table cellpadding="0" cellspacing="0" style="margin-left:5%;">
        <tr>
           <td class="style6" style="border-bottom:solid 1px gray; border-left:solid 1px gray; border-right:solid 1px gray; border-top:solid 1px gray;">         
              <asp:ListBox ID="ListBox3" Width="214px" Height="253px" runat="server" 
                   CssClass="btextlist" SelectionMode="Multiple" 
                   ></asp:ListBox></td>
                   <td>&nbsp;&nbsp;&nbsp;</td>
                 <td class="style4" style="border-bottom:solid 1px gray; border-left:solid 1px gray; border-right:solid 1px gray; border-top:solid 1px gray;">  
              <asp:ListBox ID="ListBox4" Width="214px" Height="253px" runat="server" 
                   CssClass="btextlist" style=" margin-left :0px"></asp:ListBox>                 
           </td>
           <td valign="top">
           <table style="vertical-align:top;"><tr valign="top">
              <td valign="top" class="style10">
              <asp:TextBox ID="txtfrom" style="vertical-align:top;" CssClass="btext_master" runat="server"></asp:TextBox>
              <asp:TextBox ID="txtto" style="vertical-align:top;" CssClass="btext_master" runat="server"></asp:TextBox>     
              
              </td>
              
              </tr>
              <tr>
              <td class="style10">
              <asp:Button id="btnadd" style="vertical-align:top;" Text="Add" runat="server" />
              <asp:Button id="btnclear" style="vertical-align:top;" Text="Clear" runat="server" />
              </td>
              </tr>
              <tr>
              <td colspan="2" 
                      style="border-bottom:solid 1px gray; border-left:solid 1px gray; border-right:solid 1px gray; border-top:solid 1px gray;" 
                      class="style10" >
              <asp:Label ID="lbl_filterval" runat="server" CssClass="TextField" Width="230px" Height="200px" Text=""></asp:Label>
              </td></tr>
              
              </table> 
           </td>
           
        </tr>
        </table>
     </div>
     
     
   </tr>
        
        
         <tr><td>
       <table border='1' style="width: 340px;margin-left:5%;">
       <tr>
       <td class="style11">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Order by</td>
       <td></td>
       <td>
        <asp:Button id="btnaddsort" style="vertical-align:top;" Text="Add" runat="server" />
        <asp:Button id="btnclrsort" style="vertical-align:top;" Text="Clear" runat="server" />
       </td>
       </tr>
       </table>
       </td>
       <td>
       
        <div>  
            <table cellpadding="0" cellspacing="0" style="margin-left:5%;">
                <tr>
                    <td class="style6" 
                        style="border-bottom:solid 1px gray; border-left:solid 1px gray; border-right:solid 1px gray; border-top:solid 1px gray;">         
                        <asp:ListBox ID="ListBox5" Width="214px" Height="253px" runat="server" 
                        CssClass="btextlist" 
                        ></asp:ListBox>
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;</td>
                    <td>
                      <table style="vertical-align:top;">
                       <tr valign="top">
                        <td valign="top"  style="border-bottom:solid 1px gray; border-left:solid 1px gray; border-right:solid 1px gray; border-top:solid 1px gray;"><asp:Label ID="lbl_sort_val" runat="server" CssClass="TextField" Width="210px" Height="250px" Text=""></asp:Label>
                       </td>
                    </tr>
                    </table>
                    </td>
                    <td ><%--style="vertical-align:bottom;"--%>
                        <asp:Button id="btnsubmit" style="vertical-align:top;" Text="Submit" runat="server" />
                        <asp:Button id="btnexit" style="vertical-align:top;" Text="Exit" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
   
       
       </td>
       
       </tr>
        
        
        </table>
    
    
    
            <input id="hiddendateformat" type="hidden" name="hiddendateformat" runat="server"/>        
            <input id="hiddenuserid" runat="server" type="hidden" name="hiddenuserid"/>&nbsp;
            <input id="hiddenusername" runat="server" type="hidden" name="username"/>
            <input id="hdn_user_right" type="hidden" runat="server" name="hdncompname"/>
            <input id="hiddencompcode" runat="server" type="hidden" name="hiddencompcode"/>
            <input id="hiddenselectedmenu" runat="server" type="hidden" name="hiddenselectedmenu"/>
            <input id="hiddenunit" runat="server" type="hidden" name="hiddenunit"/>
            <input id="hdnuserid" type="hidden" name="hdnuserid" runat="server" />
            <input id="hiddenunitcode" runat="server" type="hidden" name="hiddenunitcode"/>
            <input id="hdnfcpmast" type="hidden" name="hdncompcode" runat="server" />
            <input id="hdnfcpdetail" type="hidden" name="hdncompcode" runat="server" />
            <input id="hdnprgname" type="hidden" name="hdncompcode" runat="server" />
            <input id="deltblfields" type="hidden" name="hdncompcode" runat="server" />
            <input id="hdnmodvalue" type="hidden" name="hdncompcode" runat="server" />
            <input id="hdnChannel" runat="server" type="hidden" name="hiddenunit" />
            <input id="hdnLocation" type="hidden" name="hdncompcode" runat="server" />
            <input id="hdnLanguage" type="hidden" name="hdncompcode" runat="server" />
            <input id="hdnPrgtype" type="hidden" name="hdncompcode" runat="server" />
            <input id="hdnProgram" type="hidden" name="hdncompcode" runat="server" />
            <input id="hdnOriRepeatcode" type="hidden" name="hdncompcode" runat="server" />
            <input id="hdnreport" runat="server" type="hidden" name="hiddenunit" />
            <input id="hdntablename" runat="server" type="hidden" name="hiddenunit" />
            <input id="hndcon" runat="server" type="hidden"  name="hiddenunit" />
            <input id="hiddenpermission" runat="server" type="hidden"  name="hiddenpermission" />
        
    
    </form>
</body>
</html>
