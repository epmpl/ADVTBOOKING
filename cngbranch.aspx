<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cngbranch.aspx.cs" Inherits="cngbranch" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar.ascx"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Change Branch</title>
     <link href="css/cir_main.css" type="text/css" rel="stylesheet" />
      <link href="css/main.css" type="text/css" rel="stylesheet" />
      <script language="javascript" type="text/javascript" src="javascript/Agency_type.js">
       
      </script>
       <script language="javascript" type="text/javascript" src="javascript/change_branch.js">
      </script>
      <script language="javascript"  src="javascript/fix_header_for_grid.js" type="text/javascript"></script>
      <link href="css/fix_header.css" type="text/css" rel="stylesheet" />
      <script type="text/javascript"   language="javascript">        
      </script>
</head>
<body style="margin-left:0px;margin-top:0px;" onload="pagerefresh();">
    <form id="form1" runat="server">
    <div>
         <table >
            <tr>
                    <td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Change Branch"></uc1:topbar></td>
            </tr>
        </table>
         <table cellspacing="0" cellpadding="0" style="width:1000px;height:30px; " border='0'>
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
	            
        
         
	            <table cellspacing="0" cellpadding="0" style="width:1000px;" border='0'>
	            <tr>
	            <td>
	            <table  border="0" cellpadding="0" cellspacing="0"  width="100%">
	            <tr>
	            <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:130PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center> Change Branch</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:900px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:800px; height:3px;"></td></tr></table></td>
	
	            
	            
	            
	            </tr>
	            </table>
	            </td>
	            </tr>
	            </table>
        
       
      <table><tr><td style="height:25px;"></td></tr></table>
        
     
    <%--<table id="outertable" style="padding-left:80px;"  border="0" cellpadding="0" cellspacing="0">
        
	            <tr>
	            <td colspan="5">--%>
	             <div id="fake-scroll-container" >
        <div id="header-container1" >
            <table runat="server" id="table_header1" cellpadding="0" cellspacing="0">
                <tr>   
                    <th runat="server" id="head"  style="display:none;">
	      
	                </th>
     
                 </tr>
             </table>
         </div>
         
        <div id="scroll_1" runat="server">
            <table runat="server" id="table_body" cellpadding="0" cellspacing="0">
    
            </table>	
        </div>

         <div id="y-fake-scroll1">
            <div id="y-table-emulator" style="width:40px;">
                &nbsp;
            </div>
        </div>

        <div id="x-fake-scroll" >
            <div id="x-table-emulator" >
            &nbsp;
            </div>
        </div>
      
      </div>
	            <%--</td>
	         </tr>--%>
	         
	         <table style="width: 755px; height: 5px" cellspacing="0" cellpadding="0" border="0">
	        <tr>
	        <td align="center" colspan="4" style="padding-top:30px; padding-left:180px;">
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

