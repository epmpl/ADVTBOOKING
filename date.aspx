<%@ Page Language="C#" AutoEventWireup="true" CodeFile="date.aspx.cs" Inherits="date" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<HEAD>
		<title>Display Ad. Booking & Sheduling Date Previllege</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" src="javascript/tree.js"></script>
		<LINK href="css/main.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		
		function logout()
		{
		window.location.href='logout.aspx';
		return false;
		}
		function ankur(abc)
		{
		alert(abc);
		alert(document.getElementById('RadioButtonList1').value);
		
		return false;
		
		}
		
		function abc12()
{
window.location.href='module_detail.aspx';
return false;
}
function abc123()
{
window.location.href='date.aspx';
return false;
}
/*function aaa()
{
window.location.href='Agent_master.aspx';
return false;
}*/
function home()
{
window.location.href='EnterPage.aspx';
return false;
}
		
		</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" style="Z-INDEX: 101; LEFT: 16px; WIDTH: 970px; POSITION: absolute; TOP: 15px; HEIGHT: 23px"
				cellSpacing="0" cellPadding="0" width="970" border="0">
				<TR>
					<!--<TD></A><asp:label id="Label3" runat="server" Width="184px"></asp:label><A class="matter" href="#"><asp:label id="Label2" runat="server" Width="64px" Font-Size="XX-Small" ForeColor="#E82429" CssClass="matter2">Display Ad. |</asp:label></A><asp:label id="Label4" runat="server" Width="74px" Font-Size="XX-Small" CssClass="matter2">Classified Ad. |</asp:label><asp:label id="Label5" runat="server" Width="54px" Font-Size="XX-Small" CssClass="matter2">Layout-X |</asp:label><asp:label id="Label6" runat="server" Width="64px" Font-Size="XX-Small" CssClass="matter2">News-Wrap |</asp:label><asp:label id="Label7" runat="server" Width="64px" Font-Size="XX-Small" CssClass="matter2">4C-DAMS |</asp:label></TD>-->
					<td></td>
					<TD class="textfield" align="right"></TD>
				</TR>
			</TABLE>
			<TABLE id="Table3" style="Z-INDEX: 101; LEFT: 16px; WIDTH: 970px; POSITION: absolute; TOP: 35px; HEIGHT: 23px"
				cellSpacing="0" cellPadding="0" width="970" border="0">
				<TR>
					<!--<TD class="tdhover"><A class="matter2"  href="#">Booking &amp; 	Sheduling </A><font color="black"><A class="matter2"  href="#">| Billing </font></A><A class="matter2" href="#"><font color="#cc0000"></font></A></TD>-->
					<td align="right">
						<asp:LinkButton id="log" runat="server" CssClass="btnlink12" onclick="log_Click">Log Out&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton></td>
				</TR>
			</TABLE>
			
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td borderColor="#1" width="100%"><IMG src="images/img_02A.jpg" border="0"></td>
				</tr>
				<tr>
					<td borderColor="#1" width="100%"><IMG src="images/top.jpg" border="0"></td>
				</tr>
				<tr>
					<td vAlign="top">
						<table style="WIDTH: 985px" cellSpacing="0" cellPadding="0" width="985" border="0">
							<tr>
								<!---------left bar start--------->
								<td vAlign="top" width="100%" >
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr vAlign="baseline">
											<td><asp:label id="tP1" runat="server" Width="194px" CssClass="btnlink" BackColor="#7daae3" Height="20px"></asp:label></td>
											<!--<script type="text/javascript">
// Clock Script Generated By Maxx Blade's Clock v2.0d
// http://www.maxxblade.co.uk/clock
function tS1(){ x=new Date(tN1().getUTCFullYear(),tN1().getUTCMonth(),tN1().getUTCDate(),tN1().getUTCHours(),tN1().getUTCMinutes(),tN1().getUTCSeconds()); x.setTime(x.getTime()+dS1()-28800000); return x; } 
function tN1(){ return new Date(); } 
function dS1(){ return ((tN1().getTime()>fD1(0,3,1,1).getTime())&&(tN1().getTime()<fD1(0,9,1,-1).getTime()))?3600000:0; } 
function fD1(d,m,h,p){ var week=(p<0)?7*(p+1):7*(p-1),nm=(p<0)?m+1:m,x=new Date(tN1().getUTCFullYear(),nm,1,h,0,0),dOff=0; if(p<0){ x.setTime(x.getTime()-86400000); } if(x.getDay()!=d){ dOff=(x.getDay()<d)?(d-x.getDay()):0-(x.getDay()-d); if(p<0&&dOff>0){ week-=7; } if(p>0&&dOff<0){ week+=7; } x.setTime(x.getTime()+((dOff+week)*86400000)); } return x; } 
function lZ1(x){ return (x>9)?x:'0'+x; } 
function tH1(x){ if(x==0){ x=12; } return (x>12)?x-=12:x; } 
function dT1(){ document.getElementById('tP1').innerHTML=eval(oT1); setTimeout('dT1()',1000); } 
function aP1(x){ return (x>11)?' PM':' AM'; } 
function y41(x){ return (x<500)?x+1900:x; } 
var mN1=new Array('Jan','Feb','Mar','Apr','May','Jun','Jul','Aug','Sep','Oct','Nov','Dec'),oT1="mN1[tS1().getMonth()]+' '+tS1().getDate()+','+' '+y41(tS1().getYear())+' '+tH1(tS1().getHours()+3)+':'+lZ1(tS1().getMinutes()+8)+':'+lZ1(tS1().getSeconds())+aP1(tS1().getHours())";
if(!document.all){ window.onload=dT1; }else{ dT1(); }
											</script>-->
											<script type="text/javascript">

// Current Server Time script (SSI or PHP)- By JavaScriptKit.com (http://www.javascriptkit.com)
// For this and over 400+ free scripts, visit JavaScript Kit- http://www.javascriptkit.com/
// This notice must stay intact for use.

//Depending on whether your page supports SSI (.shtml) or PHP (.php), UNCOMMENT the line below your page supports and COMMENT the one it does not:
//Default is that SSI method is uncommented, and PHP is commented:

var currenttime = new Date();

//'<!--#config timefmt="%B %d, %Y %H:%M:%S"--><!--#echo var="DATE_LOCAL" -->' //SSI method of getting server date
//var currenttime = '<? print date("F d, Y H:i:s", time())?>' //PHP method of getting server date

///////////Stop editting here/////////////////////////////////

var montharray=new Array("January","February","March","April","May","June","July","August","September","October","November","December")
var serverdate=new Date(currenttime)

function padlength(what){
var output=(what.toString().length==1)? "0"+what : what
return output
}

function displaytime(){
serverdate.setSeconds(serverdate.getSeconds()+1)
var datestring=montharray[serverdate.getMonth()]+" "+padlength(serverdate.getDate())+", "+serverdate.getFullYear()
var timestring=padlength(serverdate.getHours())+":"+padlength(serverdate.getMinutes())+":"+padlength(serverdate.getSeconds())
document.getElementById("tP1").innerHTML=datestring+" "+timestring
}

window.onload=function(){
setInterval("displaytime()", 1000)
}

											</script>
										
											<td vAlign="top">
											</td>
										</tr>
							</tr>
						
					</td>
					<td vAlign="top" width="80%">
						<TABLE id="Table1" style="WIDTH: 790px" height="500" borderColorDark="#000000" cellPadding="0"
							width="790" border="0">
							<TR>
								<TD align="center" style="height: 484px">
									<TABLE id="Table4" style="LEFT: 500px; POSITION: absolute; TOP: 150px; width: 332px;" cellSpacing="1"
										cellPadding="1" border="0">
										<TR>
											<TD><asp:label id="Label1" runat="server" Width="112px" CssClass="TextField">Date Format</asp:label></TD>
											<TD style="width: 123px"><asp:dropdownlist id="drpdateformat" runat="server" CssClass="dropdown">
													<asp:ListItem Value="mm/dd/yyyy">MM/DD/YYYY</asp:ListItem>
													<asp:ListItem Value="yyyy/mm/dd">YYYY/MM/DD</asp:ListItem>
													<asp:ListItem Value="dd/mm/yyyy">DD/MM/YYYY</asp:ListItem>
												</asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD style="width: 123px"></TD>
										</TR>
										<TR>
											<TD>
                                                <asp:Label ID="auto" runat="server" CssClass="TextField" Width="128px">Code Generate Type</asp:Label></TD>
											<TD style="width: 123px"><asp:dropdownlist id="drpcodetype" runat="server" CssClass="dropdown">
                                                <asp:ListItem Value="1">Auto Generated</asp:ListItem>
                                                <asp:ListItem Value="0">User Defined</asp:ListItem>
                                            </asp:DropDownList></TD>
										</TR>
                                        <tr>
                                            <td>
                                            </td>
                                            <td style="width: 123px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label8" runat="server" CssClass="TextField" Text="Currency"></asp:Label></td>
                                            <td style="width: 123px">
                                                <asp:DropDownList ID="drpcurr" runat="server" CssClass="dropdown">
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td style="width: 123px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label19" runat="server" CssClass="TextField" Text="Rate Group Code"></asp:Label></td>
                                            <td style="width: 123px">
                                                <asp:DropDownList ID="drprategroup" runat="server" CssClass="dropdown">
                                                </asp:DropDownList></td>
                                        </tr>
										<TR>
											<TD>
                                                <asp:LinkButton ID="lbagencymaster" runat="server">Agency Master</asp:LinkButton></TD>
											<TD style="width: 123px"></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD style="width: 123px"></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD style="width: 123px"></TD>
										</TR>
										<TR>
											<TD colSpan="2" align="center">
												<asp:Button id="btnsubmit" runat="server" Text="Submit" CssClass="inputbutton" onclick="btnsubmit_Click"></asp:Button></TD>
											<TD></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
						<INPUT id="hiddencode" type="hidden" runat="server"><INPUT id="hiddenuserid" type="hidden" runat="server"><INPUT id="hiddencompcode" runat="server" type="hidden"></td>
					<!---------middle end---------></tr>
			</table>
            <div id="enable">Ankur</div>
      
        
           
			</form>
		
	</body>
</HTML>