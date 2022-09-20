<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Scheme_Master.aspx.cs" Inherits="Scheme_Master" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Scheme Master</title>
    <link href="css/main.css" type="text/css" rel="stylesheet"/>
    <script language="javascript" type="text/javascript" src="javascript/givepermission.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/popupcalender.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/datevalidation.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/Scheme_Master.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/entertotab.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/Validations.js"></script>
		
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<script language="javascript" type="text/javascript" >
function notchar2()
{
if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9)||(event.keyCode>=65 && event.keyCode<=97)||(event.keyCode>=97 && event.keyCode<=122))
{
return true;
}
else
{
return false;
}
}

function phone()
{
if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==32))
{
return true;
}
else
{
//alert("Please enter only numeric values");
return false;
}
}


function nchar()
{
if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9)||(event.keyCode==46)||(event.keyCode==13))
{
return true;
}
else
{
return false;
}
}

function chknumber_adv() {
    
    if ((event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 46) || (event.keyCode == 45))
        {
        return true;
        }
        	
        else
        {
	        return false;
        }	
 }
function chknumber_advins() {
    
 if((event.keyCode>=48 && event.keyCode<=57))
        {
        return true;
        }
        	
        else
        {
	        return false;
        }	
 }


   function notss()
        {
//          var browser=navigator.appName;
//         if(browser!="Microsoft Internet Explorer")
//         { 
//            if((event.which>=48 && event.which<=57)||(event.which==127)||(event.which==8)||(event.which==9)||(event.which>=65 && event.which<=90)||(event.which>=97 && event.which<=122)||(event.which==43)||(event.which==32))
//            {
//            return true;
//            }
//            else
//            {
//            return false;
//            }
//         }
//         else
//         {
          if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9)||(event.keyCode>=65 && event.keyCode<=90)||(event.keyCode>=97 && event.keyCode<=122)||(event.keyCode==43)||(event.keyCode==32))
            {
            return true;
            }
            else
            {
            return false;
            }
//         }

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

//function dateenter()
//{
////alert(event.keyCode);

//if((event.keyCode>=47 && event.keyCode<=57))
//{
//return true;
//}
//else
//{
//return false;
//}
//}



		</script>
		
</head>
<body onload="javascript:return clearscheme_master();" onkeypress="eventcalling(event);" style="background-color:#f3f6fd;">
    
        <form id="form1" runat="server">
    <table id="OuterTable" cellspacing="0" cellpadding="0" width="1000" border="0">
				<tr valign="top">
					<td colspan="2" ><uc1:topbar id="Topbar1" runat="server" Text="Scheme Master"></uc1:topbar>
                        </td><td></td>
				</tr>
				<tr valign="top">
					<td valign="top">
					<uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar>
					<asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager></td>
                        
                <td style="width: 796px">
                
 <table class="RightTable" id="RightTable" cellspacing="0" cellpadding="0" border="0"  >
                <tr valign="top">
					<td>
                        <asp:UpdatePanel  ID="UpdatePanel1" runat="server"><ContentTemplate>
								<asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True"  OnClick="btnNew_Click1" ></asp:ImageButton><asp:ImageButton id="btnSave" runat="server" CssClass="topbutton" Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnSave_Click" ></asp:ImageButton><asp:ImageButton id="btnModify" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnModify_Click" ></asp:ImageButton><asp:ImageButton id="btnQuery" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnQuery_Click1" ></asp:ImageButton><asp:ImageButton id="btnExecute" runat="server" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnExecute_Click" ></asp:ImageButton><asp:ImageButton id="btnCancel" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnCancel_Click1" ></asp:ImageButton><asp:ImageButton id="btnfirst" CssClass="topbutton" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnfirst_Click" ></asp:ImageButton><asp:ImageButton id="btnprevious" runat="server" Font-Size="XX-Small"
										BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnprevious_Click" ></asp:ImageButton><asp:ImageButton id="btnnext" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnnext_Click" ></asp:ImageButton><asp:ImageButton id="btnlast" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnlast_Click" ></asp:ImageButton><asp:ImageButton id="btnDelete" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnDelete_Click" ></asp:ImageButton><asp:ImageButton id="btnExit" runat="server"  Font-Size="XX-Small" BackColor="Control"
										BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" OnClick="btnExit_Click" ></asp:ImageButton>
										</ContentTemplate>
										</asp:UpdatePanel>
					</td>
			</tr>
           </table>
                </td>
                              
                 </tr>
				</table>
				<table border="0" width="100%" cellpadding="0" cellspacing="0" style="width:auto;margin:15px 30px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Scheme Master</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
			<table  style="width:auto;margin:40px 170px;" cellpadding="0" cellspacing="0" >							
									<tr>
									       <td>
                                                <asp:Label ID="lblschemecode" runat="server" CssClass="TextField"></asp:Label></td>
                                                <td style="width:200px">
                                                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                                <ContentTemplate>
                                                <asp:TextBox ID="txtschemecode" CssClass="btext1" runat="server" MaxLength="8" Enabled="False" onkeypress="return notss();"></asp:TextBox>
                                                </ContentTemplate>
                                                </asp:UpdatePanel>
                                          </td>
                                               <!--<td>
                                                    <asp:Label ID="lbcat" runat="server" CssClass="TextField"></asp:Label></td>-->
                                                    <td><asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                    <ContentTemplate>
                                                    <!--<asp:DropDownList ID="drpadcat" runat="server" CssClass="dropdown" Enabled="False">
                                                    </asp:DropDownList>-->
                                                    </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                
                                               </td>
                                           
                                    </tr>
                                        
                                        
                                        
                                        <tr>
                                        <td><asp:Label ID="lblschemename" runat="server" CssClass="TextField"></asp:Label></td>
                                        <td colspan="3" > <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                    <ContentTemplate>
                                                <asp:TextBox ID="txtschemename" CssClass="btext" runat="server" MaxLength="50" Enabled="False" onkeypress="return notss();" Width="472px"></asp:TextBox>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel></td>
                                        <%--<td></td>
                                        <td></td>--%>
                                        
                                        </tr>
                                        
                                        
                                        
                                        <tr  >
                                            <td>
                                                <asp:Label ID="lblfrominsert" runat="server" CssClass="TextField"></asp:Label>
                                            </td>
                                            <td> 
                                                  <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                                  <ContentTemplate>
                                                  <asp:TextBox ID="txtfrominsert" runat="server" onkeypress="return chknumber_advins();" CssClass="numerictext" MaxLength="6" Enabled="False"></asp:TextBox>
                                                  </ContentTemplate>
                                                  </asp:UpdatePanel>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbltoinsert" runat="server" CssClass="TextField"></asp:Label></td>
                                                <td >
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>
                                                <asp:TextBox ID="txttoinsert" runat="server" onkeypress="return chknumber_advins();" CssClass="numerictext" MaxLength="6" Enabled="False"></asp:TextBox>
                                                </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                       </tr>
                           
                                 <tr  >
                                         <td>
                                        <asp:Label ID="lblvalidfrom" runat="server" CssClass="TextField"></asp:Label></td>
                                        <td>
                                                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                                    <ContentTemplate>
                                                    <asp:TextBox ID="txtvalidfrom" runat="server" CssClass="btext1" Enabled="False" MaxLength="10" onkeypress="javascript:return dateenter(event);"  onpaste="return false;"></asp:TextBox>
                                                    <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txtvalidfrom, "mm/dd/yyyy")' height="14px" width="14px"> 
                                                    </ContentTemplate>
                                                    </asp:UpdatePanel>
                                        </td>
                                        <td>
                                                    <asp:Label ID="lblvalidto" runat="server" CssClass="TextField"></asp:Label></td>
                                         <td>
                                            <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtvalidto" runat="server" CssClass="btext1" Enabled="False" MaxLength="10" onkeypress="javascript:return dateenter(event);"  onpaste="return false;"></asp:TextBox>
                                                <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txtvalidto, "mm/dd/yyyy")' height=14 width=14> 
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        </td>
                                 </tr>
                             
                            <tr  >
                            <td><asp:Label ID="lbldiscount" runat="server" CssClass="TextField"></asp:Label></td>
                            <td><asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                            <asp:DropDownList ID="drpdiscount" runat="server" CssClass="dropdownsmall12" Enabled="False">
									   <asp:ListItem Value="0">Select</asp:ListItem>
									   <asp:ListItem Value="per">Percentage</asp:ListItem>
									  <asp:ListItem Value="fixed">Fixed</asp:ListItem>
									  <asp:ListItem Value="fixeda">Fixed Amount</asp:ListItem>
									  </asp:DropDownList>
                            
                            
                            
                                        <asp:TextBox ID="txtdiscount" runat="server" CssClass="btextsmallphonepank" Enabled="False"
                                            MaxLength="12"  onkeypress="return chknumber_adv();"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel></td>
                            <td><asp:Label ID="apponcontidate" runat="server" CssClass="TextField"></asp:Label>
                                </td>
                                <td >
                                <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                                    <ContentTemplate>
                                    <asp:CheckBox ID="chkcontidate" runat="server" CssClass="TextField" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            
                                </td>
                                <td><asp:Label ID="appaltnate" runat="server" CssClass="TextField"></asp:Label>
                                </td>
                                  <td style="width: 240px" >
                                <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                    <ContentTemplate>
                                    <asp:CheckBox ID="chkgapdate" runat="server" CssClass="TextField" />
                                    </ContentTemplate>
                                </asp:UpdatePanel></td>
                            </tr>
                            
                    
                           
                                    
                  
                                        <tr><td colspan="4">
                                         
                                                </td></tr  colspan="4"  style="width:100%;">
                                                <tr><td    colspan="4"  >
                                                
                                                
                                                    <br />
									<table id="Table5"  height="85" cellspacing="0" cellpadding="0" width="576" border="1">
										<tr>
											<td valign="top" align="center" bgColor="#7daae3" colspan="8"><asp:Label id="lbselectpubday" runat="server" ForeColor="White" Width="213px" CssClass="TextField" Text="Scheme Day"></asp:Label></td>
										</tr>
										<tr valign="top">
											<td align="center">  <asp:Label id="Label12" runat="server" CssClass="TextField">SUN</asp:Label></td>
											<td align="center"><asp:Label id="Label13" runat="server" CssClass="TextField">MON</asp:Label></td>
											<td align="center"><asp:Label id="Label14" runat="server" CssClass="TextField">TUE</asp:Label></td>
											<td align="center"><asp:Label id="Label15" runat="server" CssClass="TextField">WED</asp:Label></td>
											<td align="center"><asp:Label id="Label16" runat="server" CssClass="TextField">THU</asp:Label></td>
											<td align="center"><asp:Label id="Label17" runat="server" CssClass="TextField">FRI</asp:Label></td>
											<td align="center"><asp:Label id="Label19" runat="server" CssClass="TextField">SAT</asp:Label></td>
											<td align="center"><asp:Label id="Label18" runat="server" CssClass="TextField">ALL</asp:Label></td>
										</tr>
										<tr valign="top">
											<td align="center"><asp:UpdatePanel ID="UpdatePanel8" runat="server"><ContentTemplate>   <asp:CheckBox id="CheckBox1" runat="server" CssClass="textfield" onload="CheckBox1_Load"></asp:CheckBox></ContentTemplate></asp:UpdatePanel></td>
											<td align="center"><asp:UpdatePanel ID="UpdatePanel6" runat="server"><ContentTemplate><asp:CheckBox id="CheckBox2" runat="server" CssClass="textfield"></asp:CheckBox></ContentTemplate></asp:UpdatePanel></td>
											<td align="center"><asp:UpdatePanel ID="UpdatePanel7" runat="server"><ContentTemplate><asp:CheckBox id="CheckBox3" runat="server" CssClass="textfield"></asp:CheckBox></ContentTemplate></asp:UpdatePanel></td>
											<td align="center"><asp:UpdatePanel ID="UpdatePanel9" runat="server"><ContentTemplate><asp:CheckBox id="CheckBox4" runat="server" CssClass="textfield"></asp:CheckBox></ContentTemplate></asp:UpdatePanel></td>
											<td align="center"><asp:UpdatePanel ID="UpdatePanel10" runat="server"><ContentTemplate><asp:CheckBox id="CheckBox5" runat="server" CssClass="textfield"></asp:CheckBox></ContentTemplate></asp:UpdatePanel></td>
											<td align="center"><asp:UpdatePanel ID="UpdatePanel15" runat="server"><ContentTemplate><asp:CheckBox id="CheckBox6" runat="server" CssClass="textfield"></asp:CheckBox></ContentTemplate></asp:UpdatePanel></td>
											<td align="center"><asp:UpdatePanel ID="UpdatePanel16" runat="server"><ContentTemplate><asp:CheckBox id="CheckBox7" runat="server" CssClass="textfield"></asp:CheckBox></ContentTemplate></asp:UpdatePanel></td>
											<td align="center"><asp:UpdatePanel ID="UpdatePanel17" runat="server"><ContentTemplate><asp:CheckBox id="CheckBox8" runat="server" CssClass="textfield"></asp:CheckBox></ContentTemplate></asp:UpdatePanel></td>
										</tr>
										
										 </td></tr>
										
									</table>
                        <br />
                                                
                                                
                                                
                                                
                                                
                                </table>
				<input id="hiddencompcode" type="hidden" size="1" name="Hidden2" runat="server"/>
        <input id="hiddenusername" type="hidden" size="1" name="Hidden2" runat="server"/>
        <input id="hiddendateformat" runat="server" name="Hidden2" size="1" type="hidden" />
        <input id="hiddenuserid" type="hidden" size="1" name="Hidden2" runat="server"/>
        <input id="hiddenauto" type="hidden" size="1" name="Hidden23" runat="server"/>
         <input id="hiddenprem" type="hidden" size="1" name="Hidden23" runat="server"/>&nbsp;
        
       <asp:UpdatePanel ID="UpdatePanel28" runat="server">
         <ContentTemplate> 
               <input id="hiddenshow" type="hidden" size="1" name="Hidden2" runat="server"/>
               <input id="hiddenmod" type="hidden" size="1" name="Hidden2" runat="server"/>
              <asp:Label ID="d2" runat="server"></asp:Label>
         </ContentTemplate>
       </asp:UpdatePanel>
        
    </form>
    
    
    
</body>
</html>
