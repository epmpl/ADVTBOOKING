<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditionWise_RatioEntry.aspx.cs" Inherits="EditionWise_RatioEntry" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Edition Wise Ratio Entry Form</title>
     <link href="css/main.css" type="text/css" rel="stylesheet"/>
     <script language="javascript" type="text/javascript" src="javascript/EditionWise_RatioEntry.js"></script>
     <script language="javascript" type="text/javascript" src="javascript/entertotab.js"></script>
	<script language="javascript" type="text/javascript" src="javascript/Validations.js"></script>
	<script language="javascript" type="text/javascript" src="javascript/givepermission.js"></script>
	<script language="javascript" type="text/javascript" src="javascript/datevalidation.js"></script>
	
	 <script type="text/javascript" language="javascript">
    function rateenter(evt)
    {
       //alert(evt.keyCode);
        var charCode = (evt.which) ? evt.which : event.keyCode
        if((charCode>=46 && charCode<=57 && charCode!=47)||(charCode==127)||(charCode==8)||(charCode==9))
        {
           return true;
        }
        else
        {
           return false;
        }
     }
   
    </script>
</head>
<body onload="onpage_load(); givebuttonpermission('EditionWise_RatioEntry');" onkeydown="javascript:return tabvaluescheme(event,'drpedition');" style="background-color:#f3f6fd;"> <!---->
  <form id="form1" runat="server">
    <table id="OuterTable" cellspacing="0" cellpadding="0" width="1000" border="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" text="Box Master"></uc1:topbar></td>
				</tr>
				<tr valign="top" >
					<td valign="top" style="width: 184px"><uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar></td>
					<td valign="top" style="width: 796px">
						<table class="RightTable" runat="server"  id="RightTable" cellspacing="0" cellpadding="0" border="0" >
							<tr valign="top">
								       <td style="padding-left:-1px">
								<asp:ImageButton id="btnNew" runat="server" CssClass="topbutton"  Font-Size="XX-Small"
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
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Edition Wise Ratio</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>
			<table  style="width:auto;margin:40px 170px;" cellpadding="0" cellspacing="0" >
            <tr><td height="20px">
            
                   <table cellspacing="0"	cellpadding="0" style="WIDTH: 710px;" align="center" border="0">									
					  <tr>
                            <td align="right">
                                <asp:Label ID="lbleditionname" runat="server" CssClass="TextField"></asp:Label>
                            </td>
                            <td style="width:10px"></td>
                            <td > 
                            
                                <asp:DropDownList ID="drpedition" CssClass="dropdown" runat="server" ></asp:DropDownList>
                            </td>
                            
                    </tr>
                    <tr>
                         <td colspan="5" style="height:15px"></td>
                    </tr>
                    </table>
                    <table align="center">
                    <tr id="tblbutton" style="display:block">
                         <td  colspan="5" align="center" style="width:65%">
                             <asp:Button ID="btnok" Text="OK" BorderStyle="Outset" BackColor="Control" Font-Size="XX-Small"  CssClass="topbutton" runat="server" />
                         </td>
                         
                    </tr>
                    </table>
                    
<tr>
			           <td colspan="5">
			              <table id="tblgrid" cellspacing="0" cellpadding="0"  style="display:block" align="center" border="1" width="60%" >
			              </table>
			            </td>
		            </tr>
		            </td></tr>
              </table>
	    <input id="hiddencompcode" type="hidden" size="1" name="Hidden2" runat="server"/>
        <input id="hiddenusername" type="hidden" size="1" name="Hidden2" runat="server"/>
        <input id="hiddendateformat" runat="server" name="Hidden2" size="1" type="hidden" />
        <input id="hiddenuserid" type="hidden" size="1" name="Hidden2" runat="server"/>
        <input id="hiddenauto" type="hidden" size="1" name="Hidden23" runat="server"/>
         <input id="hiddenprem" type="hidden" size="1" name="Hidden23" runat="server"/>&nbsp;
                
    </form>
</body>
</html>
