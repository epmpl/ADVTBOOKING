<%@ Page Language="C#" AutoEventWireup="true" CodeFile="qbc_alleditions_rpt.aspx.cs" Inherits="Reports_qbc_alleditions_rpt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>All Editions Business Report</title>
	<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1"/>
		<meta name="CODE_LANGUAGE" content="C#"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
		<style type="text/css">.style1 { FONT-WEIGHT: bold; COLOR: #ffffff; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif }
	.style2 { COLOR: #ffffff }
		</style>
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<link href="css/booking.css" type="text/css" rel="stylesheet"/>
		<link href="css/report.css" type="text/css" rel="stylesheet"/>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <script type="text/javascript" language="javascript" src="javascript/jquery.min.js"></script>
    <script type="text/javascript" language="javascript" src="javascript/CommonFunction.js"></script>
    <script type="text/javascript" language="javascript" src="javascript/jquery.freezeheader.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/datevalidation.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/qbc_alleditions_rpt.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/popupcalender.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/rept.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/new.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/validatationdate.js"></script>
		<style type="text/css">.style1 { FONT-WEIGHT: bold; FONT-SIZE: xx-large; COLOR: #ffffff }
	.style2 { COLOR: #ffffff }
	.style4 { FONT-WEIGHT: normal; FONT-SIZE: 14pt; COLOR: #d85414; FONT-FAMILY: Verdana }
	.style6 { FONT-SIZE: x-small }
	.style7 { FONT-WEIGHT: bold; COLOR: #6666ff }
		</style>
		<script language="javascript" type="text/javascript">
		    function forfocus() {
		        //document.getElementById('Txtusernme').focus();
		    }
		    function maximize() {
		        window.moveTo(0, 0)
		        window.resizeTo(screen.availWidth, screen.availHeight)
		    }
		    maximize();
		</script>
</head>
<body  onkeydown="javascript:return EnterTab(event,this)" style="margin: 0px 0px 0px 0px;"><form id="form1" runat="server">
<div id="divedtn" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lstedtn" Width="280px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox></td></tr></table></div> 
<div id="divunit" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lstunit" Width="280px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox></td></tr></table></div>
<div id="divbrn" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lstbrn" Width="280px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox></td></tr></table></div>
<div id="divpublication" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lstpublication" Width="280px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox></td></tr></table></div> 
<div id="divact" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lstact" Width="280px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox></td></tr></table></div> 
<div id="divloc" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lstloc" Width="280px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox></td></tr></table></div> 
<div id="divacttype" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lstacttype" Width="210px" Height="85px" runat="server" CssClass="dropdown" ></asp:ListBox></td></tr></table></div>
<div id="divgifttype" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;"><table cellpadding="0" cellspacing="0"><tr><td><asp:ListBox ID="lstgifttype" Width="210px" Height="85px" runat="server" CssClass="dropdown" ></asp:ListBox></td></tr></table></div>      
    <table width="1005" border="0" cellspacing="0" cellpadding="0" align="center" style="WIDTH: 1005px; HEIGHT: 358px">
				<tr>
					<td width="100%" bordercolor="#1"><img src="images/img_02A.jpg" width="1004" border="0" />
                      <%--  <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>--%>
                    </td>
				</tr>
				<tr>
					<%--<td width="100%" bordercolor="#1"><img src="images/top.jpg" width="1004" border="0" /></td>--%>
					<td  id="td2"  onclick="javascript:return logoutpage();"   width="100%" bordercolor="#1" style="background-image:url('images/top.jpg');font-family:Trebuchet MS;font-size: 13px;color:#CC0000;cursor:hand;" align="right">
                     Logout</td>
				</tr>
    </td>
    </tr>   

<tr><td>

<table id="outertbl" cellpadding="4" cellspacing="4" border="2" style="width:800px;border-color:#a0bfeb; margin-left:80px">
<tr>
<td id="innertbl">
<table style="width:824px; border-color:black" cellpadding="0" cellspacing="0" 
        border="0">
            <tr>
            <td style="width:200px"><asp:Label ID="lblcomp_name" runat="server" CssClass="TextField" ></asp:Label></td>
            <td style="width:250px"><asp:TextBox ID="txtcomp_name" runat="server" CssClass="cls_schname" ></asp:TextBox></td>
            <td style="width:200px"><asp:Label ID="lblcomp_code" runat="server" CssClass="TextField"></asp:Label></td>
            <td style="width:150px"><asp:TextBox ID="txtcomp_code" runat="server" 
                    CssClass="cls_schname" Width="148px" ></asp:TextBox></td>
            </tr>

            <tr>
            <td style="width:200px"><asp:Label ID="lbl_unit" runat="server" CssClass="TextField" ></asp:Label></td>
            <td style="width:250px"><asp:TextBox ID="txt_unit" runat="server" CssClass="cls_schname" ></asp:TextBox></td>
            <td style="width:200px"><asp:Label ID="lbl_unitcode" runat="server" CssClass="TextField"></asp:Label></td>
            <td style="width:150px"><asp:TextBox ID="txt_unitcode" runat="server" 
                    CssClass="cls_schname" Width="148px" ></asp:TextBox></td>
            </tr>


            <tr>
            <td style="width:200px"><asp:Label ID="lblbranch" runat="server" CssClass="TextField" ></asp:Label></td>
            <td style="width:250px"><asp:TextBox ID="txtbranch" runat="server" CssClass="cls_schname" ></asp:TextBox></td>
            <td style="width:200px"><asp:Label ID="lblbranch_code" runat="server" CssClass="TextField"></asp:Label></td>
            <td style="width:150px"><asp:TextBox ID="txtbranch_code" runat="server" 
                    CssClass="cls_schname" Width="148px" ></asp:TextBox></td>
            </tr>
            <tr >
            <td ><asp:Label ID="lblfromdate" runat="server" CssClass="TextField"></asp:Label></td>
            <td style="width: 167px"><asp:TextBox  id="txtfromdate" runat="server" CssClass="cls_schname" MaxLength="10"></asp:TextBox>
            <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txtfromdate,"mm/dd/yyyy")' height="14" width="14"/></td>
            <td><asp:Label ID="lbltodate" runat="server" CssClass="TextField"></asp:Label></td>
            <td style="width: 167px"><asp:TextBox  id="txttodate" runat="server" 
                    CssClass="cls_schname" MaxLength="10" Height="16px" Width="141px"></asp:TextBox>
            <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txttodate,"mm/dd/yyyy")' height="14" width="14"/></td>
            </tr>
     

            
             <tr>
             <td style="width:200px"><asp:Label ID="lbldest" runat="server" CssClass="TextField" ></asp:Label></td>
            <td style="width:250px"><asp:DropDownList runat="server" ID="txtdest" CssClass="dropdown" >
      
            </asp:DropDownList></td>

            <td style="width:200px"><asp:Label ID="lbldatetyp" runat="server" CssClass="TextField" ></asp:Label></td>
            <td style="width:250px"><asp:DropDownList runat="server" ID="drpdatetype"  CssClass="dropdown" ></asp:DropDownList></td>

            
            
            </tr>
            <tr>
            <td style="width:200px"><asp:Label ID="lblyeartyp" runat="server" CssClass="TextField" ></asp:Label></td>
            <td style="width:250px"><asp:DropDownList runat="server" ID="drpyeartyp"  
                    CssClass="dropdown" Width="143px" ></asp:DropDownList></td>
                    
                    
                <td style="width:200px"><asp:Label ID="lbl_year_month" runat="server" CssClass="TextField" ></asp:Label></td>
            <td style="width:250px"><asp:DropDownList runat="server" ID="drp_year_month"  CssClass="dropdown" ></asp:DropDownList></td>

            
            </tr>
            </table>
            </table>
            </td>
            </tr>
            

 <tr style ="height:40px">
      <td colspan ="2" align ="center" ><asp:Button runat ="server" ID="btnsubmit" Text="Report" Width="56px" Height="26px" /><asp:Button ID="btncancel" runat="server" Text="Clear" Width="56px" Height="26px"  /><asp:Button ID="btnexit" runat="server" Text="Exit" Width="56px" Height="26px" /></td>
      </tr>
     
    <input type="hidden" runat="server" id="hdncom_name" />
    <input type="hidden" runat="server" id="hdndateformat" />
    <input type="hidden" runat="server" id="hdncomp_code" />
    <input type="hidden" runat="server" id="hdnuserid" />
    <input type="hidden" runat="server" id="hiddenconnection" />
    <input type="hidden" runat="server" id="hdnpublication" />
    <input type="hidden" runat="server" id="hiddendateformat" />
    
    <input type="hidden" runat="server" id="hdnflg" />



    </form>
</body>
</html>
