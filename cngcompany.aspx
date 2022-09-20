<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cngcompany.aspx.cs" Inherits="cngcompany" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar.ascx"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Change Company</title>
     <link href="css/cir_main.css" type="text/css" rel="stylesheet" />
      <link href="css/main.css" type="text/css" rel="stylesheet" />
          <script language="javascript" type="text/javascript" src="javascript/change_comp.js">
      </script>
      <script type="text/javascript" language="javascript">
       
      </script>
</head>
<body style="margin-left:0px;margin-top:0px;" onload="pagerefresh();">
    <form id="form1" runat="server">
    <div>
         <table >
            <tr>
                    <td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Change Company"></uc1:topbar></td>
            </tr>
        </table>
  
       <%-- <td valign="top" style="width: 184px">
            <uc2:leftbar id="Leftbar1" runat="server"></uc2:leftbar>
        </td>--%>
	
	        
	            <%--<tr>
	                <td valign="top" width=700 colspan=5>
	                <table align='right'>
	                <tr>
	                    <td>
	                        <asp:button Visible=false id="btnclear" runat="server" CssClass="topbutton" Width="63px" Font-Size="XX-Small"
	                        BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" Height="24px" Text='Clear'></asp:button>
                             <asp:button id="btnexit" runat="server" CssClass="topbutton" Width="63px" Font-Size="XX-Small" Text='Exit'
	                        BackColor="Control" BorderStyle="Outset" BorderColor="DarkGray" Font-Bold="True" Height="24px"></asp:button>
                    
                        </td>
	                </tr>
	               </table>
	              </td>
	            </tr>--%>
	            <table  cellspacing="0" cellpadding="0" style="width:1000px;height:30px; " border='0'>
	            <tr>
	            <td>
	            <table>
	            <tr>
	            <td></td>
	            </tr>
	            </table>
	            </td>
	            </tr>
	            </table>
	            
	            <table  cellspacing="0" cellpadding="0" style="width:1000px;" border='0'>
	            <tr>
	            <td>
	            <table  border="0" cellpadding="0" cellspacing="0"  width="100%">
	            <tr>
	            <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:130PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center> Change Company</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:900px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:800px; height:3px;"></td></tr></table></td>
	
	            
	            
	            
	            </tr>
	            </table>
	            </td>
	            </tr>
	            </table>
	            
	            
	            <table   cellspacing="0" cellpadding="0" style="width:700px;" border='0'> 
	            <tr>
	            <td>
	                <table style="width: 755px; height: 23px" cellspacing="0" cellpadding="0" border="0">
	                
	                <tr >
	                    <td width="100%"  id="result" runat="server" style="padding-left:100px">
	                       
	                    </td>
	                </tr>
	                <tr>
	                <tr>
	                </tr>
	                <tr>
	                </tr>
	                </tr>
	                </table>
	            </td>
	         </tr>
	        <tr>
	        <td colspan=4 style="padding-top:10px;padding-left:300px;">
	            <input type="button" runat="server" id='btnsubmit' value="Submit" style="width:90px;height:24px;font-size:xx-small;border-style:outset; border-color:gray;Font-weight:bold;" />
	        <input type="button" runat="server" id='btnexit' value="Exit" style="width:90px;height:24px;font-size:xx-small;border-style:outset; border-color:gray;Font-weight:bold;" />
	        </td>
	        </tr>
		</table>
       <input type="hidden" runat="server" id="hdncompcode" />
    <input type="hidden" runat="server" id="hdncompname" />
    <input type="hidden" runat="server" id="hdnuserid" />
    <input type="hidden" runat="server" id="hdnunitcode" />
    <input type="hidden" runat="server" id="hdncentername" />
    <input type="hidden" runat="server" id="HDN_server_date" />
    <input type="hidden" runat="server" id="fields" />
    <input type="hidden" runat="server" id="wfields" />
    <input type="hidden" runat="server" id="old_value" />
    <input type="hidden" runat="server" id="hdn_user_right" />
    <input type="hidden" runat="server" id="hiddendateformat" />
    
    </div>
    </form>
</body>
</html>

