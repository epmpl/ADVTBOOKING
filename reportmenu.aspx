<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reportmenu.aspx.cs" Inherits="reportmenu" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/tr/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Report</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1"/>
		<meta name="CODE_LANGUAGE" content="C#"/>
		<meta name="vs_defaultClientScript" content="JavaScript"/>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5"/>
		<style type="text/css">.style1 { FONT-WEIGHT: bold; COLOR: #ffffff; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif }
	.style2 { COLOR: #ffffff }
		</style>
		
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
   <%-- <a href="javascript/chrome.js">javascript/chrome.js</a>
   <A HREF="javascript/reportmenu.js">javascript/reportmenu.js</A>--%>
   <%-- <script type="text/javascript"  language="javascript" src="reportmenu.js"></script>--%>
     <script type="text/javascript" language="javascript" src="javascript/chrome.js"></script>
   <%-- <link rel="stylesheet" type="text/css" href="chromestyle2.css" />--%>
  <script type="text/javascript"language="javascript" src="javascript/reportmenu.js"></script>
    <link href="chromestyle.css" rel="stylesheet" type="text/css" />
    <link href="chromestyle.css" rel="stylesheet" type="text/css" />
  <%--  <link href="csch/chromestyle.css" runat="server" type="text/css" /> --%>
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
					<td width="100%" bordercolor="#1"><img src="images/top.jpg" width="1004" border="0" /></td>
				</tr>
				<tr>
					<td style="height: 505px"><table width="985" border="0" cellspacing="0" cellpadding="0" style="WIDTH: 985px; HEIGHT: 486px">
					
							<tr>
								<!---------left bar start--------->
								<td style="WIDTH: 200px"><img src="images/leftbar.jpg" style="WIDTH: 193px; HEIGHT: 483px" height="483" width="193" /></td>
								<!---------left bar end--------->
								<!---------middle start--------->
								
		<td valign="top" style="width: 10%">
		<div  class="chromestyle" id="chromemenu" style="width: 18%" >
              <ul style="width: 84%; height: 8px">
                <li><a href="#" rel="dropmenu1" class="menucss">AdReport</a>
            </li>
            </ul>
        </div>
        <!--1st drop down menu -->
            <%--<li><a href="#" rel="dropmenu1"><span style="color: #494949">AD REPORT</span></a>
                <%-- <li><a href="#" rel="dropmenu1">Resources</a></li>
                <li><a href="#" rel="dropmenu2">News</a></li>
                <li><a href="#" rel="dropmenu3">Search</a></li>--%>
           <%-- </li>
        </ul>--%>
        
        <div id="dropmenu1" class="dropmenudiv">
         <a href="javascript:adofday()">All Ads Of A Day</a>
            <a href="javascript:adofage()">All Ads Of The Agency</a>
            <a href="javascript:adofagencli()">All Ads Of The Client</a>
           <a href="javascript:liadofholdcan()">Status Based Ad List </a> 
           <a href="javascript:divatonrp()">Devation Report</a> 
           <a href="javascript:pagepre()">Page Premium Report</a> 
           
           
           
           
           
          <%-- <a href="javascript:clientdet()">CLIENT DETAIL FOR PARTICULER INDUSTRY</a>--%>
           
           
        </div>
        <%--<!--2nd drop down menu -->
        <div id="dropmenu2" class="dropmenudiv" style="width: 150px;">
            <a href="http://www.cnn.com/">CNN</a> 
            <a href="http://www.msnbc.com">MSNBC</a> 
            <a href="http://news.bbc.co.uk">BBC News</a>
        </div>
        <!--3rd drop down menu -->
        <div id="dropmenu3" class="dropmenudiv" style="width: 150px;">
            <a href="http://www.google.com/">Google</a>
            <a href="http://www.yahoo.com">Yahoo</a>
            <a href="http://www.msn.com">MSN</a>
        </div>--%>

        <script type="text/javascript">
            cssdropdown.startchrome("chromemenu")
        </script>
        
				</td>
				<td valign="top" style="width: 10%">
		<div  class="chromestyle" id="chromemenu1" style="width: 18%" >
              <ul style="width: 44%; height: 8px">
                <li><a href="#" rel="dropmenu2" class="menucss">MisReport</a>
            </li>
            </ul>
        </div>
        <!--1st drop down menu -->
            <%--<li><a href="#" rel="dropmenu1"><span style="color: #494949">AD REPORT</span></a>
                <%-- <li><a href="#" rel="dropmenu1">Resources</a></li>
                <li><a href="#" rel="dropmenu2">News</a></li>
                <li><a href="#" rel="dropmenu3">Search</a></li>--%>
           <%-- </li>
        </ul>--%>
        
        <div id="dropmenu2" class="dropmenudiv">
         <%--<a href="javascript:adofday()">ALL ADS OF A DAY</a>
            <a href="javascript:adofage()">ALL ADS OF THE AGENCY</a>
            <a href="javascript:adofagencli()">ALL ADS OF THE CLIENT</a>
           <a href="javascript:liadofholdcan()">STATUS BASED AD LIST </a> 
           <a href="javascript:divatonrp()">DEVIATION REPORT</a> 
           <a href="javascript:pagepre()">PAGE PREMIUM REPORT</a> --%>
           <a href="javascript:clientdet()">Pi Report Product Wise</a>
           <%-- <a href="javascript:productdet()">PI REPORT PRODUCT WISE</a>--%>
             <a href="javascript:regiondet()">Pi Report Region Wise</a>
              <a href="javascript:publicationdet()">Pi Report Publication Wise</a>
            <%--  <a href="javascript:scheme()">Pi Scheme Report</a>--%>
              <a href="javascript:contractt()">Pi Contract Report</a>
               <%--<a href="javascript:upcountry()">Pi Report  REPORT UPCOUNTRY</a>--%>
           
        </div>
        <%--<!--2nd drop down menu -->
        <div id="dropmenu2" class="dropmenudiv" style="width: 150px;">
            <a href="http://www.cnn.com/">CNN</a> 
            <a href="http://www.msnbc.com">MSNBC</a> 
            <a href="http://news.bbc.co.uk">BBC News</a>
        </div>
  
}
        <!--3rd drop down menu -->
        <div id="dropmenu3" class="dropmenudiv" style="width: 150px;">
            <a href="http://www.google.com/">Google</a>
            <a href="http://www.yahoo.com">Yahoo</a>
            <a href="http://www.msn.com">MSN</a>
        </div>--%>

        <script type="text/javascript">
            cssdropdown.startchrome("chromemenu1")
        </script>
    
				</td>
			
				<td valign="top" style="width: 10%">
		<div  class="chromestyle" id="chromemenu2" style="width: 20%" >
              <ul style="width: 98%; height: 8px">
                <li><a href="#" rel="dropmenu3" class="menucss">SchReport</a>
            </li>
            </ul>
        </div>
        <!--1st drop down menu -->
            <%--<li><a href="#" rel="dropmenu1"><span style="color: #494949">AD REPORT</span></a>
                <%-- <li><a href="#" rel="dropmenu1">Resources</a></li>
                <li><a href="#" rel="dropmenu2">News</a></li>
                <li><a href="#" rel="dropmenu3">Search</a></li>--%>
           <%-- </li>
        </ul>--%>
        
        <div id="dropmenu3" class="dropmenudiv">
         <%--<a href="javascript:adofday()">ALL ADS OF A DAY</a>
            <a href="javascript:adofage()">ALL ADS OF THE AGENCY</a>
            <a href="javascript:adofagencli()">ALL ADS OF THE CLIENT</a>
           <a href="javascript:liadofholdcan()">STATUS BASED AD LIST </a> 
           <a href="javascript:divatonrp()">DEVIATION REPORT</a> 
           <a href="javascript:pagepre()">PAGE PREMIUM REPORT</a> --%>
           <a href="javascript:schedule()">Schedule Register Report</a>
           <%-- <a href="javascript:productdet()">PI REPORT PRODUCT WISE</a>--%>
             <%--<a href="javascript:regiondet()">PI REPORT REGION WISE</a>
              <a href="javascript:publicationdet()">PI REPORT PUBLICATION WISE</a>
               <a href="javascript:upcountry()">PI REPORT UPCOUNTRY</a>--%>
           
        </div>
        <%--<!--2nd drop down menu -->
        <div id="dropmenu2" class="dropmenudiv" style="width: 150px;">
            <a href="http://www.cnn.com/">CNN</a> 
            <a href="http://www.msnbc.com">MSNBC</a> 
            <a href="http://news.bbc.co.uk">BBC News</a>
        </div>
  
}
        <!--3rd drop down menu -->
        <div id="dropmenu3" class="dropmenudiv" style="width: 150px;">
            <a href="http://www.google.com/">Google</a>
            <a href="http://www.yahoo.com">Yahoo</a>
            <a href="http://www.msn.com">MSN</a>
        </div>--%>

        <script type="text/javascript">
            cssdropdown.startchrome("chromemenu2")
        </script>
    
				</td>
				<td valign="top" style="width: 10%">
		<div  class="chromestyle" id="chromemenu3" style="width: 20%" >
              <ul style="width: 98%; height: 8px">
                <li><a href="#" rel="dropmenu4" class="menucss">ClientReport</a>
            </li>
            </ul>
        </div>
        <!--1st drop down menu -->
            <%--<li><a href="#" rel="dropmenu1"><span style="color: #494949">AD REPORT</span></a>
                <%-- <li><a href="#" rel="dropmenu1">Resources</a></li>
                <li><a href="#" rel="dropmenu2">News</a></li>
                <li><a href="#" rel="dropmenu3">Search</a></li>--%>
           <%-- </li>
        </ul>--%>
        
        <div id="dropmenu4" class="dropmenudiv">
         <%--<a href="javascript:adofday()">ALL ADS OF A DAY</a>
            <a href="javascript:adofage()">ALL ADS OF THE AGENCY</a>
            <a href="javascript:adofagencli()">ALL ADS OF THE CLIENT</a>
           <a href="javascript:liadofholdcan()">STATUS BASED AD LIST </a> 
           <a href="javascript:divatonrp()">DEVIATION REPORT</a> 
           <a href="javascript:pagepre()">PAGE PREMIUM REPORT</a> --%>
           <a href="javascript:clientdetail()">Client Detail</a>
           <%-- <a href="javascript:productdet()">PI REPORT PRODUCT WISE</a>--%>
             <%--<a href="javascript:regiondet()">PI REPORT REGION WISE</a>
              <a href="javascript:publicationdet()">PI REPORT PUBLICATION WISE</a>
               <a href="javascript:upcountry()">PI REPORT UPCOUNTRY</a>--%>
           
        </div>
        <%--<!--2nd drop down menu -->
        <div id="dropmenu2" class="dropmenudiv" style="width: 150px;">
            <a href="http://www.cnn.com/">CNN</a> 
            <a href="http://www.msnbc.com">MSNBC</a> 
            <a href="http://news.bbc.co.uk">BBC News</a>
        </div>
  
}
        <!--3rd drop down menu -->
        <div id="dropmenu3" class="dropmenudiv" style="width: 150px;">
            <a href="http://www.google.com/">Google</a>
            <a href="http://www.yahoo.com">Yahoo</a>
            <a href="http://www.msn.com">MSN</a>
        </div>--%>

        <script type="text/javascript">
            cssdropdown.startchrome("chromemenu3")
        </script>
    
				</td>
				<td valign="top" style="width: 60%">
		<div  class="chromestyle" id="chromemenu4" style="width: 20%" >
              <ul style="width: 50%; height: 8px">
                <li><a href="#" rel="dropmenu5" class="menucss">BillingReport</a>
            </li>
            </ul>
        </div>
        <!--1st drop down menu -->
            <%--<li><a href="#" rel="dropmenu1"><span style="color: #494949">AD REPORT</span></a>
                <%-- <li><a href="#" rel="dropmenu1">Resources</a></li>
                <li><a href="#" rel="dropmenu2">News</a></li>
                <li><a href="#" rel="dropmenu3">Search</a></li>--%>
           <%-- </li>
        </ul>--%>
        
        <div id="dropmenu5" class="dropmenudiv">
         
            
            <a href="javascript:billingreg()">Billing Register</a>
            <a href="javascript:barterbill()">Barter Wise Billing</a>
           <a href="javascript:valuereppub()">Value Report Publication Wise</a> 
           <a href="javascript:valuerep()">Value Report Region Wise</a> 
           <a href="javascript:regrebate()">Rebate Report Region Wise</a> 
           <a href="javascript:pubrebate()">Rebate Report Publication Wise</a>
           <a href="javascript:extrebate()">Extra Rebate Report</a>
           <a href="javascript:retainCom()">Retainer Commision Report</a>
           <%--<a href="javascript:cashdisc()">Cash Discount Report </a>--%> 
           <%--<a href="javascript:retaincommission()">Retai </a> --%>
           <%--<a href="javascript:billreg()">Bill Register</a>--%>
             <%--<a href="javascript:regiondet()">PI REPORT REGION WISE</a>
              <a href="javascript:publicationdet()">PI REPORT PUBLICATION WISE</a>
               <a href="javascript:upcountry()">PI REPORT UPCOUNTRY</a>--%>
           
        </div>
        <%--<!--2nd drop down menu -->
        <div id="dropmenu2" class="dropmenudiv" style="width: 150px;">
            <a href="http://www.cnn.com/">CNN</a> 
            <a href="http://www.msnbc.com">MSNBC</a> 
            <a href="http://news.bbc.co.uk">BBC News</a>
        </div>
  
}
        <!--3rd drop down menu -->
        <div id="dropmenu3" class="dropmenudiv" style="width: 150px;">
            <a href="http://www.google.com/">Google</a>
            <a href="http://www.yahoo.com">Yahoo</a>
            <a href="http://www.msn.com">MSN</a>
        </div>--%>

        <script type="text/javascript">
            cssdropdown.startchrome("chromemenu4")
        </script>
    
				</td>
				
				
				
				</tr>
				</table>
				</td>
				
				</tr>
							
     </table>
     
     
		
    </form>
</body>
</html>

