<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PubRebateview2.aspx.cs" Inherits="PubRebateview2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
     <title>Rebate Report Publication Wise</title>
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
		<script type="text/javascript"  language="javascript" src="javascript/popupcalender.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script type="text/javascript" language="javascript" src="javascript/rept.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/prototype.js"></script>
		<%--<script type="text/javascript" language="javascript" src="javascript/piproduct.js"></script>--%>
		<script type="text/javascript" language="javascript" src="javascript/disschreg.js"></script>
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
		
		 function opendiv()
    {
    
        if($('Txtdest').value==3)
        {
       
            if($('divpdf1').style.display=="none")

            {
//           if($('divpdf').style.display=="none")
//          {
//          $('divpdf').style.display=="block"
//          }
             $('divpdf1').style.display="block"
            
            }
            if($('divpdf').style.display=="none")
          {
          $('divpdf').style.display="block"
          }
       }
    else
    {
   
        if($('divpdf1').style.display=="block")

         {
//         if($('divpdf').style.display=="block")
//          {
//          $('divpdf').style.display=="none"
//          }
             $('divpdf1').style.display="none"
                 
         }
            if($('divpdf').style.display=="block")
          {
          $('divpdf').style.display="none"
          }
    }



    }
///////////////////////////////////////////////////////////////////////		
		
						function drill_out()
		{
				if($('Txtdest').value==3)
		{
				
				var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 
                loadXML('xml/pdf.xml');   
                var alrt;
                alrt=document.getElementById('lbpdfsortvalue').innerText;    
                if(alrt.indexOf('*')>=0)
                {
                if(document.getElementById('txtpdfsortvalue').value=="0")
                {
            //alrt.Replace("*","");
                var abc=alrt.replace("*","");
                alert('Please Enter '+ abc);
                document.getElementById('txtpdfsortvalue').focus();
                return false;
                }
                }
    
   
    
               alrt=document.getElementById('lbpdfsort').innerText;
               if(alrt.indexOf('*')>=0)
               {
               if(document.getElementById('txtpdfsort').value=="0")
               {
               var abc=alrt.replace("*","");
               alert('Please Enter '+ abc);
               document.getElementById('txtpdfsort').focus();
               return false;
               }
               }
		    try
	{
		if(typeof(window.opener)!="undefined")
		{
		
				var x_win = window.self;
				
				while(x_win!="undefined")
				{
					x_win = x_win.opener;
					
					if(typeof(x_win.opener)=="undefined")
					{
						var h="y";
						//alert('zsx')
						var selectedcat="";
						var mylength=$('dpcategory').lenght;
						
						if($('divpdf').style.display=="block")
						
						{
						
						x_win.location.href="Pubrebateview.aspx?fromdate=" + $('txtfrmdate').value + "&todate=" +$('txttodate1').value  + "&region=" + $('dpregion').value +  "&agency=" +$('dpagency').value  + "&client=" + $('dpclient').value + "&publication=" + $('dppub').value + "&adtype=" + $('dpadtype').value + "&payment=" + $('dppayment').value  + "&category=" + $('dpcategory').value  +"&billstatus=" + $('dpbillstatus').value + "&drilout=" + "yes" + "&destination=" + $('Txtdest').value+ "&sortorder=" + $('txtpdfsort').value + "&sortvalue=" + $('txtpdfsortvalue').value;
						}
						else
						{
						x_win.location.href="Pubrebateview.aspx?fromdate=" + $('txtfrmdate').value + "&todate=" +$('txttodate1').value  + "&region=" + $('dpregion').value +  "&agency=" +$('dpagency').value  + "&client=" + $('dpclient').value + "&publication=" + $('dppub').value + "&adtype=" + $('dpadtype').value + "&payment=" + $('dppayment').value  + "&category=" + $('dpcategory').value  +"&billstatus=" + $('dpbillstatus').value + "&drilout=" + "yes" + "&destination=" + $('Txtdest').value+ "&sortorder=" + "50"+ "&sortvalue=" + "50";
						}
						//window.open("epapermain.aspx?queryed="+a+"&getda=h&eddate="+b);
						//alert(x_win.location.href)
						window.close() 
					break;
					}
				}
		}
		else
		{
	
			window.location.href="Pubrebateview.aspx?fromdate=" + $('txtfrmdate').value + "&todate=" +$('txttodate1').value  + "&region=" + $('dpregion').value +  "&agency=" +$('dpagency').value  + "&client=" + $('dpclient').value + "&publication=" + $('dppub').value + "&adtype=" + $('dpadtype').value + "&payment=" + $('dppayment').value + "&billstatus=" + $('dpbillstatus').value + "&category=" + $('dpcategory').value  + "&drilout=" + "yes" + "&destination=" + $('Txtdest').value+ "&sortorder=" + $('txtpdfsort').value + "&sortvalue=" + $('txtpdfsortvalue').value;
			//window.open("epapermain.aspx?queryed="+a+"&getda=h&eddate="+b);
		}
	}
	catch(e)
	{
	window.open("/");
	}
	}
	else
	{
	try
	{
		if(typeof(window.opener)!="undefined")
		{
		
				var x_win = window.self;
				
				while(x_win!="undefined")
				{
					x_win = x_win.opener;
					
					if(typeof(x_win.opener)=="undefined")
					{
						var h="y";
						//alert('zsx')
						var selectedcat="";
						var mylength=$('dpcategory').lenght;
						
						if($('divpdf').style.display=="block")
						
						{
						
						x_win.location.href="Pubrebateview.aspx?fromdate=" + $('txtfrmdate').value + "&todate=" +$('txttodate1').value  + "&region=" + $('dpregion').value +  "&agency=" +$('dpagency').value  + "&client=" + $('dpclient').value + "&publication=" + $('dppub').value + "&adtype=" + $('dpadtype').value + "&payment=" + $('dppayment').value  + "&category=" + $('dpcategory').value  +"&billstatus=" + $('dpbillstatus').value + "&drilout=" + "yes" + "&destination=" + $('Txtdest').value+ "&sortorder=" + $('txtpdfsort').value + "&sortvalue=" + $('txtpdfsortvalue').value;
						}
						else
						{
						x_win.location.href="Pubrebateview.aspx?fromdate=" + $('txtfrmdate').value + "&todate=" +$('txttodate1').value  + "&region=" + $('dpregion').value +  "&agency=" +$('dpagency').value  + "&client=" + $('dpclient').value + "&publication=" + $('dppub').value + "&adtype=" + $('dpadtype').value + "&payment=" + $('dppayment').value  + "&category=" + $('dpcategory').value  +"&billstatus=" + $('dpbillstatus').value + "&drilout=" + "yes" + "&destination=" + $('Txtdest').value+ "&sortorder=" + "50"+ "&sortvalue=" + "50";
						}
						//window.open("epapermain.aspx?queryed="+a+"&getda=h&eddate="+b);
						//alert(x_win.location.href)
						window.close() 
					break;
					}
				}
		}
		else
		{
	
			window.location.href="Pubrebateview.aspx?fromdate=" + $('txtfrmdate').value + "&todate=" +$('txttodate1').value  + "&region=" + $('dpregion').value +  "&agency=" +$('dpagency').value  + "&client=" + $('dpclient').value + "&publication=" + $('dppub').value + "&adtype=" + $('dpadtype').value + "&payment=" + $('dppayment').value + "&billstatus=" + $('dpbillstatus').value + "&category=" + $('dpcategory').value  + "&drilout=" + "yes" + "&destination=" + $('Txtdest').value+ "&sortorder=" + $('txtpdfsort').value + "&sortvalue=" + $('txtpdfsortvalue').value;
			//window.open("epapermain.aspx?queryed="+a+"&getda=h&eddate="+b);
		}
	}
	catch(e)
	{
	window.open("/");
	}
	}
		}
////////////////////////////////////////////////////////////////////////////////////////////////////////////////
function drill_out()
		{
			//***********************************************************
        if($('Txtdest').value==3)
		{
				//alert($('Txtdest').value)
				var xmlDoc = new ActiveXObject("Microsoft.XMLDOM"); 
                loadXML('xml/pdf.xml');   
                var alrt;
                alrt=document.getElementById('lbpdfsortvalue').innerText;    
                if(alrt.indexOf('*')>=0)
                {
                if(document.getElementById('txtpdfsortvalue').value=="0")
                {
            //alrt.Replace("*","");
                var abc=alrt.replace("*","");
                alert('Please Enter '+ abc);
                document.getElementById('txtpdfsortvalue').focus();
                return false;
                }
                }
    
   
    
               alrt=document.getElementById('lbpdfsort').innerText;
               if(alrt.indexOf('*')>=0)
               {
               if(document.getElementById('txtpdfsort').value=="0")
               {
               var abc=alrt.replace("*","");
               alert('Please Enter '+ abc);
               document.getElementById('txtpdfsort').focus();
               return false;
               }
               }
     
        //************************************************************	//alert(a)
		    try
	       {
	       
 //*******************************************************************************************
	       var myrange="";
	       var myrangeid="";
	       var myvalue="";
	       var userrange="";
		     if(typeof(window.opener)!="undefined")
		     {
		
				var x_win = window.self;
				
				while(x_win!="undefined")
				{
					x_win = x_win.opener;
					
					if(typeof(x_win.opener)=="undefined")
					{
						var h="y";
//*******************************************************************************************
						
						for(k=0;k<$('txtrange').options.length;k++)
			{
			    if($('txtrange').options[k].selected==true)
			    {
			        myrange=$('txtrange').options[k].value;
			        myrangeid=k;
			        break;
			    }
			}
			if(myrange!="")
			{
			     myvalue= $('arrayval').value.split("~");
			     for(j=0;j<myvalue.length-1;j++)
			     {
			        if(j==k)
			        {
			        
			            userrange=myvalue[j];
			        }
			        
			     }
			     
			}//alert($('Txtdest').value+'2nd')
			            if(userrange=="" || userrange== undefined)
						{//alert('852')
						userrange="no";
						//alert(userrange)
						}
						else
						{
						}
//*******************************************************************************************
			        
						if($('divpdf').style.display=="block")
						
						{//alert('divif')
						//alert(userrange)
						//alert(myrange)
						//alert($('Txtdest').value+'3rd')
						x_win.location.href="Pubrebateview.aspx?fromdate=" + $('txtfrmdate').value + "&todate=" +$('txttodate1').value  + "&region=" + $('dpregion').value +  "&agency=" +$('dpagency').value  + "&client=" + $('dpclient').value + "&publication=" + $('dppub').value + "&adtype=" + $('dpadtype').value + "&payment=" + $('dppayment').value  + "&category=" + $('dpcategory').value  +"&billstatus=" + $('dpbillstatus').value + "&myrange=" + myrange +"&userrange="+ userrange + "&drilout=" + "yes" + "&destination=" + $('Txtdest').value+ "&sortorder=" + $('txtpdfsort').value + "&sortvalue=" + $('txtpdfsortvalue').value;
						
						}
						else
						{//alert('divelse')
						x_win.location.href="Pubrebateview.aspx?fromdate=" + $('txtfrmdate').value + "&todate=" +$('txttodate1').value  + "&region=" + $('dpregion').value +  "&agency=" +$('dpagency').value  + "&client=" + $('dpclient').value + "&publication=" + $('dppub').value + "&adtype=" + $('dpadtype').value + "&payment=" + $('dppayment').value  + "&category=" + $('dpcategory').value  +"&billstatus=" + $('dpbillstatus').value  +"&myrange=" + myrange +"&userrange="+ userrange + "&drilout=" + "yes" + "&destination=" + $('Txtdest').value+ "&sortorder=" + "50"+ "&sortvalue=" + "50";
						
						}
						
						window.close() 
					break;
					}
				}
		}
		else
		{//alert('else')
	      x_win.location.href="Pubrebateview.aspx?fromdate=" + $('txtfrmdate').value + "&todate=" +$('txttodate1').value  + "&region=" + $('dpregion').value +  "&agency=" +$('dpagency').value  + "&client=" + $('dpclient').value + "&publication=" + $('dppub').value + "&adtype=" + $('dpadtype').value + "&payment=" + $('dppayment').value  + "&category=" + $('dpcategory').value  +"&billstatus=" + $('dpbillstatus').value + "&myrange=" + myrange +"&userrange="+ userrange + "&drilout=" + "yes" + "&destination=" + $('Txtdest').value+ "&sortorder=" + $('txtpdfsort').value + "&sortvalue=" + $('txtpdfsortvalue').value;
			
		}
		}
	
	catch(e)
	{
	window.open("/");
	}
		}
		
		else
	
	{
	try
	       {
		     if(typeof(window.opener)!="undefined")
		     {
		
				var x_win = window.self;
				
				while(x_win!="undefined")
				{
					x_win = x_win.opener;
					
					if(typeof(x_win.opener)=="undefined")
					{
						var h="y";
						
			//*******************************************************************************************			
						for(k=0;k<$('txtrange').options.length;k++)
			{
			    if($('txtrange').options[k].selected==true)
			    {//alert(myrange)
			        myrange=$('txtrange').options[k].value;
			        myrangeid=k;
			        break;
			    }
			}
			if(myrange!="")
			{
			     myvalue= $('arrayval').value.split("~");
			     for(j=0;j<myvalue.length-1;j++)
			     {
			        if(j==k)
			        {
			            userrange=myvalue[j];
			        }
			     }
			}
			//alert(userrange)
			if(userrange=="" || userrange== undefined)
						{
						//alert(userrange)
						userrange="no";
						}
						else
						{
						}
						
	//*******************************************************************************************					
						//x_win.location.href="BillRegisterview.aspx?fromdate=" + $('txtfrmdate').value + "&todate=" +$('txttodate1').value  + "&region=" + $('dpregion').value +  "&agency=" +$('dpagency').value  + "&client=" + $('dpclient').value + "&publication=" + $('dppub').value + "&adtype=" + $('dpadtype').value + "&payment=" + $('dppayment').value + "&billstatus=" + $('dpbillstatus').value + "&drilout=" + "yes" + "&destination="+"1";
						if($('divpdf').style.display=="block")
						
						{
						//alert('xyz')
						   x_win.location.href="RegionRebateview.aspx?fromdate=" + $('txtfrmdate').value + "&todate=" +$('txttodate1').value  + "&region=" + $('dpregion').value +  "&agency=" +$('dpagency').value  + "&client=" + $('dpclient').value + "&publication=" + $('dppub').value + "&adtype=" + $('dpadtype').value + "&payment=" + $('dppayment').value  + "&category=" + $('dpcategory').value  +"&billstatus=" + $('dpbillstatus').value + "&myrange=" + myrange +"&userrange="+ userrange  + "&drilout=" + "yes" + "&destination=" + $('Txtdest').value+ "&sortorder=" + $('txtpdfsort').value + "&sortvalue=" + $('txtpdfsortvalue').value;
						    //x_win.location.href="BillRegisterview.aspx?region=" + $('dpregion').value +  "&agency=" +$('dpagency').value  + "&client=" + $('dpclient').value + "&publication=" + $('dppub').value + "&adtype=" + $('dpadtype').value + "&payment=" + $('dppayment').value + "&billstatus=" + $('dpbillstatus').value  +"&myrange=" + myrange +"&userrange="+ userrange + "&drilout=" + "yes" + "&destination=" + $('Txtdest').value + "&sortorder=" + $('txtpdfsort').value + "&sortvalue=" + $('txtpdfsortvalue').value;
						}
						else
						{//alert('abc')
						      x_win.location.href="RegionRebateview.aspx?fromdate=" + $('txtfrmdate').value + "&todate=" +$('txttodate1').value  + "&region=" + $('dpregion').value +  "&agency=" +$('dpagency').value  + "&client=" + $('dpclient').value + "&publication=" + $('dppub').value + "&adtype=" + $('dpadtype').value + "&payment=" + $('dppayment').value  + "&category=" + $('dpcategory').value  +"&billstatus=" + $('dpbillstatus').value  +"&myrange=" + myrange +"&userrange="+ userrange + "&drilout=" + "yes" + "&destination=" + $('Txtdest').value+ "&sortorder=" + "50"+ "&sortvalue=" + "50";
						   // x_win.location.href="BillRegisterview.aspx?region=" + $('dpregion').value +  "&agency=" +$('dpagency').value  + "&client=" + $('dpclient').value + "&publication=" + $('dppub').value + "&adtype=" + $('dpadtype').value + "&payment=" + $('dppayment').value + "&billstatus=" + $('dpbillstatus').value  +"&myrange=" + myrange +"&userrange="+ userrange + "&drilout=" + "yes" + "&destination=" + $('Txtdest').value + "&sortorder=" + "50"+ "&sortvalue=" + "50";
						}
						
						window.close() 
					break;
					}
				}
		}
		else
		{//alert('++')
	         x_win.location.href="RegionRebateview.aspx?fromdate=" + $('txtfrmdate').value + "&todate=" +$('txttodate1').value  + "&region=" + $('dpregion').value +  "&agency=" +$('dpagency').value  + "&client=" + $('dpclient').value + "&publication=" + $('dppub').value + "&adtype=" + $('dpadtype').value + "&payment=" + $('dppayment').value  + "&category=" + $('dpcategory').value  +"&billstatus=" + $('dpbillstatus').value + "&myrange=" + myrange +"&userrange="+ userrange  + "&drilout=" + "yes" + "&destination=" + $('Txtdest').value+ "&sortorder=" + $('txtpdfsort').value + "&sortvalue=" + $('txtpdfsortvalue').value;
			//window.location.href="BillRegisterview.aspx?fromdate=" + $('txtfrmdate').value + "&todate=" +$('txttodate1').value  + "&region=" + $('dpregion').value +  "&agency=" +$('dpagency').value  + "&client=" + $('dpclient').value + "&publication=" + $('dppub').value + "&adtype=" + $('dpadtype').value + "&payment=" + $('dppayment').value + "&billstatus=" + $('dpbillstatus').value + "&drilout=" + "yes" + "&destination="+"1";
			//x_win.location.href="BillRegisterview.aspx?region=" + $('dpregion').value +  "&agency=" +$('dpagency').value  + "&client=" + $('dpclient').value + "&publication=" + $('dppub').value + "&adtype=" + $('dpadtype').value + "&payment=" + $('dppayment').value + "&billstatus=" + $('dpbillstatus').value  +"&myrange=" + myrange +"&userrange="+ userrange  + "&drilout=" + "yes" + "&destination=" + $('Txtdest').value+ "&sortorder=" + $('txtpdfsort').value + "&sortvalue=" + $('txtpdfsortvalue').value;
		}
	}
	catch(e)
	{
	window.open("/");
	}
		}
	
	}		
//		function maximize()
//        {
//        window.moveTo(0,0)            
//        window.resizeTo(screen.availWidth, screen.availHeight)
//         }
//        maximize();
		</script>
</head>
<body>
    <form id="pubrebateview2" runat="server">
    <table  border="0" cellspacing="0" cellpadding="0" align="center" style="WIDTH: 50px; HEIGHT: 50px">
				<tr>
					<td width="100%" bordercolor="#1"><img src="images/img_02A.jpg" width="500" height="40" border="0" />
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                    </td>
				</tr>
				
				
				<tr>
					<td width="100%" bordercolor="#1"><img src="images/top.jpg" width="500" border="0" /></td>
				</tr>
				</table> 
										
										<tr>
											<td align="center" >
											<table align="center" ><tr>
											<td><asp:Label ID="heading" runat ="server" CssClass="heading"></asp:Label></td></tr>
											</table>
											<br />
											
											<table   align="center"  width="0" border="0" cellspacing="0" cellpadding="2">
											
											       
											              
											       
													
													
													
													
													<tr>
														<td align="left" >
														<asp:Label id="lbDateFrom" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox id="txtfrmdate" runat="server" CssClass="btext1"  ReadOnly="true"></asp:TextBox>
                                                                   <%-- <img src='Images/cal1.gif'  onclick='popUpCalendar(this, pubrebateview2.txtfrmdate, "mm/dd/yyyy")' onfocus="abc();" height=14 width=14/>--%>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        
													</tr>
													<tr>
													<td align="left">
														<asp:Label id="lbToDate" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox id="txttodate1" runat="server" CssClass="btext1" ReadOnly="true" ></asp:TextBox>
                                                                    <%--<img src='Images/cal1.gif'  onclick='popUpCalendar(this, pubrebateview2.txttodate1, "mm/dd/yyyy")' onfocus="abc();" height="14" width="14"/>--%>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
														
                                                       	</tr>
                                                       	
                                                       	<tr>
                                                       	
                                                       	<td align="left">
                                                        <asp:Label id="lbregion" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                            <asp:UpdatePanel ID="UpdatePane21" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList id="dpregion" runat="server" CssClass="dropdown"   ></asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        
                                                        </tr>
                                                        
                                                        
                                                        
                                                        
                                                   
		
                                                        <tr>
                                                        
													<td align="left"><asp:Label id="lbcatgory" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left"><asp:UpdatePanel ID="UpdatePanel2" runat="server" >
                                                                <ContentTemplate>
                                                                     <asp:DropDownList id="dpcategory" runat="server" CssClass="dropdown"></asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
													</tr>
												<tr>
                                                        
													<td align="left"><asp:Label id="lblagency" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left"><asp:UpdatePanel ID="UpdatePanel5" runat="server" >
                                                                <ContentTemplate>
                                                                     <asp:DropDownList id="dpagency" runat="server" CssClass="dropdown"></asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
													</tr>
													<tr>
                                                        
													<td align="left"><asp:Label id="lblclient" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left"><asp:UpdatePanel ID="UpdatePanel6" runat="server" >
                                                                <ContentTemplate>
                                                                     <asp:DropDownList id="dpclient" runat="server" CssClass="dropdown"></asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
													</tr>
													<tr>
                                                        
													<td align="left"><asp:Label id="lblpub" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left"><asp:UpdatePanel ID="UpdatePanel7" runat="server" >
                                                                <ContentTemplate>
                                                                     <asp:DropDownList id="dppub" runat="server" CssClass="dropdown"></asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
													</tr>
													
													<tr>
                                                        
													<td align="left"><asp:Label id="lbladtype" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left"><asp:UpdatePanel ID="UpdatePanel9" runat="server" >
                                                                <ContentTemplate>
                                                                     <asp:DropDownList id="dpadtype" runat="server" CssClass="dropdown"></asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
													</tr>
													
													<tr>
                                                        
													<td align="left"><asp:Label id="lblpayement" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left"><asp:UpdatePanel ID="UpdatePanel8" runat="server" >
                                                                <ContentTemplate>
                                                                     <asp:DropDownList id="dppayment" runat="server" CssClass="dropdown"></asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
													</tr>
													<tr>
                                                        
													<td align="left"><asp:Label id="lblbillstatus" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left"><asp:UpdatePanel ID="UpdatePanel10" runat="server" >
                                                                <ContentTemplate>
                                                                     <asp:DropDownList id="dpbillstatus" runat="server" CssClass="dropdown"></asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
													</tr>
													
														<%--for range--%>
													 <tr><td align="left">
                                                        <asp:Label id="lbrange" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                            
                                                                
                                                       <asp:DropDownList id="txtrange" runat="server" CssClass="dropdown"   ></asp:DropDownList>
                                                                
                                                        </td></tr>
													<%--for range--%>
													
													
														 <tr><td align="left">
                                                        <asp:Label id="lbdestination" runat="server" CssClass="TextField"></asp:Label></td>
														<td  align="left">
                                                            <asp:UpdatePanel ID="UpdatePanel66" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList id="Txtdest" runat="server" CssClass="dropdown" type="password"></asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td></tr>
														
													
                                                         <tr>
                                                         <td colspan="3">                                                       
                                                         <div id="divpdf1" runat="server" style="display:none;">
                                                          <table>
                                                          <tr>
                                                          <td style="width: 75px">
                                                          <asp:Label id="lbpdfsortvalue" runat="server" CssClass="TextField"></asp:Label>
                                                          </td>
                                                          <td>
                                                          <asp:DropDownList id="txtpdfsortvalue" runat="server" CssClass="dropdown" ></asp:DropDownList>
                                                          </td>
                                                          </tr>
                                                          </table>   
                                                        </div>
                                                        </td>
                                                        </tr>
                                                         
                                                         <tr>
                                                         <td colspan="3">                                                       
                                                         <div id="divpdf" runat="server" style="display:none;">
                                                          <table>
                                                          <tr>
                                                          <td style="width: 75px">
                                                          <asp:Label id="lbpdfsort" runat="server" CssClass="TextField"></asp:Label>
                                                          </td>
                                                          <td>
                                                          <asp:DropDownList id="txtpdfsort" runat="server" CssClass="dropdown" ></asp:DropDownList>
                                                          </td>
                                                          </tr>
                                                          </table>   
                                                        </div>
                                                        </td>
                                                        </tr>
														
													
													</table>
													
													
													<table  align="center" >
													
													
													<tr >
														<td >
                                                                
                                                                    <asp:button id="BtnRun" CssClass="btntext" Runat="server" ></asp:button>
                                                              
                                                               
                                                            </td>
                                                            
                                                            
                                                            <td >
                                                                
                                                                    <asp:button id="Btncancel" CssClass="btntext" Runat="server" ></asp:button>
                                                              
                                                               
                                                            </td>
                                                            
                                                            <td >
                                                                
                                                                    <asp:button id="Btnreset" CssClass="btntext" Runat="server" ></asp:button>
                                                              
                                                               
                                                            </td>
                                                        
                                                            
													</tr>
													
													
													
													
													</table>
													
														<table>
						<tr><td>
                        <input id="hiddendateformat" type="hidden" runat="server" /></td>
                         <td><input id="hiddendateformat1" type="hidden" runat="server" /></td>
                           <td><input id="hiddendateformat2" type="hidden" runat="server" /></td>
                            <td> <input type="hidden" id="arrayval" runat="server" /></td>
                         
			</tr>
				
			</table>

    </form>
</body>
</html>
