<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reportmenu.aspx.cs" Inherits="reportmenu" %>
<%--<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>--%>
.
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/tr/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Report Menu</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1"/>
		<meta name="CODE_LANGUAGE" content="C#"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
		<style type="text/css">.style1 { FONT-WEIGHT: bold; COLOR: #ffffff; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif }
	.style2 { COLOR: #ffffff }
		</style>
		
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
       <script type="text/javascript" language="javascript" src="javascript/chrome.js"></script>
   <script type="text/javascript"language="javascript" src="javascript/reportmenu.js"></script>
    <link href="chromestyle.css" rel="stylesheet" type="text/css" />
    <link href="chromestyle.css" rel="stylesheet" type="text/css" />
  
		<link href="css/main.css" type="text/css" rel="stylesheet"/>
		<link href="css/booking.css" type="text/css" rel="stylesheet"/>
		<link href="css/report.css" type="text/css" rel="stylesheet"/>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
		<script type="text/javascript"  language="javascript" src="javascript/popupcalender.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<style type="text/css">.style1 { FONT-WEIGHT: bold; FONT-SIZE: xx-large; COLOR: #ffffff }
	.style2 { COLOR: #ffffff }
	.style4 { FONT-WEIGHT: normal; FONT-SIZE: 14pt; COLOR: #d85414; FONT-FAMILY: Verdana }
	.style6 { FONT-SIZE: x-small }
	.style7 { FONT-WEIGHT: bold; COLOR: #6666ff }
		</style>
		<script language="javascript" type="text/javascript">
		function logoutpage()
{
    var c;
    //alert(typeof(formopen));
    //alert(win);
    if(typeof(win)!="undefined")
    {
        win.close();
    }
    window.location.href="../logout.aspx";
    window.close();
    return false;
}
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
<body onkeydown="javascript:return tabvalue();" >
    <form id="report1"  runat="server">
  
			<table width="1005" border="0" cellspacing="0" cellpadding="0" align="center" style="WIDTH: 1005px; HEIGHT: 358px">
				<tr>
					<td width="100%" bordercolor="#1"><img src="images/img_02A.jpg" width="1004" border="0" />
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                    </td>
				</tr>
				<tr>
					<%--<td width="100%" bordercolor="#1"><img src="images/top.jpg" width="1004" border="0" /></td>--%>
					<td  id="td2"     width="100%" bordercolor="#1" style="background-image:url('images/top.jpg');font-family:Trebuchet MS;font-size: 13px;color:#CC0000;" align="right">
                     
                     <asp:Label id="log_out" style="cursor:hand;" onclick="javascript:return logoutpage();" runat="server" Text="Logout"/>
                     </td>
				</tr>
				<tr>
					<td style="height: 505px"><table width="985" border="0" cellspacing="0" cellpadding="0" style="WIDTH: 985px; HEIGHT: 486px">
					
							<tr>
								<!---------left bar start--------->
								<td style="WIDTH: 200px"><img src="images/leftbar.jpg" style="WIDTH: 193px; HEIGHT: 483px" height="483" width="193" /></td>
								<!---------left bar end--------->
								<!---------middle start--------->
								
		<td valign="top">
		<div  class="chromestyle" id="chromemenu" >
              <ul >
                <li><a href="#" rel="dropmenu1" class="menucss" >AdReport</a>
            </li>
            </ul>
        </div>
        <!--1st drop down menu -->
           
        
        <div id="dropmenu1" class="dropmenudiv">
              <a  href="javascript:all_mast()" id="all_mast" runat="server" >All Master Lists</a>
         <a  href="javascript:adofday()" id="all_day" runat="server" >All Ads Of A Day</a>
            <a  href="javascript:adofage()" id="all_agency" runat="server">All Ads Of The Agency</a>
            <a  href="javascript:adofagencli()" id="all_client" runat="server">All Ads Of The Client</a>
           <a href="javascript:liadofholdcan()" id="status_based" runat="server">Status Based Ad List </a> 
           <a href="javascript:divatonrp()" id="deviation" runat="server">Deviation Report</a> 
           <a href="javascript:pagepre()" id="page_prem" runat="server">Page Premium Report</a> 
           <a href="javascript:IssBuss()" id="issuewise" runat="server">IssueWise Business Report</a>
           
           
           
           <a href="javascript:issuebillreport()" id="issue_billreport" runat="server">Issue Billwise Report</a>
            <a href="javascript:RevneueSummary()" id="revenuesummary" runat="server">Revenue Summary Report</a>
            <a href="javascript:TopAgency()" id="topagencli" runat="server">Top Agency/Client Analysis Report</a>
            <a href="javascript:Executivewise()" id="executive_wise" runat="server">Executive Wise Report</a>
			 <a href="javascript:avaipagepre()" id="available_prem" runat="server">Available Premium Date</a>
			   <a href="javascript:category()" id="category_wise" runat="server">Category Wise Report</a>
			      <a href="javascript:summerized()" id="status_wise_daily" runat="server">Status Wise Daily Summarized Report</a>
			      <a href="javascript:dealrep()" id="dealreport" runat="server">Deal Report</a>
			      <a href="javascript:unregisteredclient()" id="unregistered_client" runat="server">Unregistered Client</a>
              <a href="javascript:Boxregister()" id="boxregister" runat="server">Box Register</a>
             <a href="javascript:auditor_comment()" id="auditor_comment" runat="server">Auditor Comment</a>
             <a href="javascript:ad_rep_roapproval_detail()" id="ad_rep_roapproval_detail" runat="server">Ro Approval Detail</a>
              <a href="javascript:reotype()" id="reotype" runat="server"> User List Report</a>
         <a href="javascript:cardrat()" id="Cardrat" runat="server">Card Rate</a>
          <a href="javascript:BillRegister_Chklst()" id="BillRegister_Chklst" runat="server">Bill Register Chklst</a>
              <a href="javascript:bookingmasterrpt()" id="bookingmasterrpt" runat="server">Adbooking Master Report</a>
              <a href="javascript:admasterreport()" id="admasterreport" runat="server">Adbooking Report</a>
            <a href="javascript:bookingmaterialdata()" id="bookingmaterialdata" runat="server">Adbooking Material Report</a>
           
           
        </div>
        

        <script type="text/javascript">
            cssdropdown.startchrome("chromemenu")
        </script>
        
				</td>
				<td valign="top">
		<div  class="chromestyle" id="chromemenu1">
              <ul >
                <li><a href="#" rel="dropmenu2" class="menucss">MisReport</a>
            </li>
            </ul>
        </div>
        
        
        <div id="dropmenu2" class="dropmenudiv">
           <a href="javascript:clientdet()" id="pi_reports" runat="server">Pi Reports</a>
                <a href="javascript:contractt()" id="pi_contract" runat="server">Pi Contract Report</a>
			    <a href="javascript:representative()" id="exe_ret_wise" runat="server">Executive/Retainer Wise Business Report</a>
			    <a href="javascript:issueprint()" id="A1" runat="server">Issue Wise Printing Center Report</a>
			    <a href="javascript:offline()" id="A2" runat="server">Offline Mode Report</a>
			    <a href="javascript:vtsreport()" id="vts_report" runat="server">VTS Report</a>
			    <a href="javascript:bookingreport()" id="booking_report" runat="server">Booking Report</a>
			    <a href="javascript:issueedition()" id="issue_edition" runat="server">Issue Edition Wise Report</a>
			    <a href="javascript:catgwise()" id="catg_report" runat="server">Category Wise Report</a>
			    <a href="javascript:ctrdatereport()" id="ctrdatereport" runat="server">Category Date Wise Report</a>
			    <a href="javascript:targetanalisis()" id="A3" runat="server">Target Analisis Report</a>
			   <%-- <a href="javascript:targetanalisis()" id="A4" runat="server">Master Report</a>--%>
			    <a href="javascript:Ad_bussiness_target()" id="A5" runat="server">Bussiness Target Analysis Report</a>
			    
			 
			 
              
        </div>
       

        <script type="text/javascript">
            cssdropdown.startchrome("chromemenu1")
        </script>
    
				</td>
			
				<td valign="top" >
		<div  class="chromestyle" id="chromemenu2" >
              <ul >
                <li><a href="#" rel="dropmenu3" class="menucss">SchReport</a>
            </li>
            </ul>
        </div>
       
        
        <div id="dropmenu3" class="dropmenudiv">
        
           <a href="javascript:schedule()" id="schedule_report" runat="server">Schedule Register Report</a>
              <a href="javascript:con_schedule()" id="consolidated" runat="server">Consolidated Schedule Register</a>
           <a href="javascript:complete()" id="complete_report" runat="server">Complete Report</a>
           <a href="javascript:netreport()" id="net_amt_report" runat="server">Net Amount Report</a>
           <a href="javascript:ro_agency()" id="ro_agency" runat="server">R.O. Report</a>
          <a href="javascript:attendenceregister()" id="attendence_report" runat="server">Attendence Register Report</a>
           
        </div>
       

        <script type="text/javascript">
            cssdropdown.startchrome("chromemenu2")
        </script>
    
				</td>
			
				<td valign="top" style="width: 60%">
		<div  class="chromestyle" id="chromemenu4" style="width: 20%" >
              <ul>
                <li><a href="#" rel="dropmenu5" class="menucss">BillingReport</a>
            </li>
            </ul>
        </div>
        
        <div id="dropmenu5" class="dropmenudiv">
            <a href="javascript:invoice()" id="invoice" runat="server">Invoice Register</a>
            <a href="javascript:billingreg()" id="bill_register" runat="server">Billing Register</a>
            <a href="javascript:month_bill()" id="month_bill" runat="server">Month Wise Billing Report</a>
            <a href="javascript:barterbill()" id="booking_type_report" runat="server">Booking Type Wise Report</a>
           <a href="javascript:valuerep()" id="rebate_report" runat="server">Rebate Reports</a> 
           <a href="javascript:retainCom()" id="retainer_commission" runat="server">Retainer Commision Report</a>
            <a href="javascript:moneyrecieved()" id="money_report" runat="server">Money Recieved Report</a>
           <a href="javascript:datewise_billing()" id="billing_report" runat="server">Date Wise Billing Report</a>
           <a href="javascript:weekwise_billing()" id="weekly_report" runat="server">Week wise and Publication wise Revenue</a>
           <a href="javascript:case_register_rep()" id="case_register" runat="server">case register</a>
            <a href="javascript:eyecather_report()" id="eyecater_report" runat="server">Eyecather wise Business Report</a>
             <a href="javascript:CrditDebit()" id="CrditDebit" runat="server">Statement For Debit and Credit Report</a>
             <a href="javascript:qbc_alleditions_rpt()" id="qbc_alleditions_rpt" runat="server">All Editions Business</a>
        </div>

        <script type="text/javascript">
            cssdropdown.startchrome("chromemenu4")
        </script>
    
				</td>
		
		<td align="right" valign="top"  >
                                                        <asp:LinkButton id="lblprefer" runat="server" CssClass="TextField" Text="Preferences"  Visible="false" ></asp:LinkButton></td>
		
				<td align="right" valign="top"  >
                                                        <asp:Label Visible="false" id="lblpubcentpermit" runat="server" CssClass="TextField" Text="Allow Pubcent Permission" Width="150px" ></asp:Label></td>
														<td style="HEIGHT: 25px" align="right" valign="top">
                                                           
                                                                    <asp:DropDownList Visible="false"  id="dpdpubcentpermit"  runat="server" CssClass="dropdown"  Width="80">
                                                                    <asp:ListItem  Value="0" Text="No"   ></asp:ListItem>
                                                                    <asp:ListItem  Value="1" Text="Yes"   ></asp:ListItem>   </asp:DropDownList>
                                                               
                                                        </td>
                                                        
                                                        	<%--<td valign="top" >
		 <a href="javascript:accessrights()" >Access_Rights</a>
				</td>--%>
		
	  <%--	 ////////////////////////////////////////////////////////////////////////////////////////////////// --%>
				
				</tr>
				</table>
				</td>
				
				</tr>
							
     </table>
       <input id="hiddencompcode" type="hidden" name="hiddencompcode" runat="server" />
         <input id="hiddenuserid" type="hidden" name="hiddenuserid" runat="server" />
          <input id="hiddenpermission" type="hidden" name="hiddenpermission" runat="server" />
           <input id="hiddenconnection" type="hidden" name="hiddenconnection" runat="server" />
     
		
    </form>
</body>
</html>

