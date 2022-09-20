<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cash_recipt.aspx.cs" Inherits="cash_recipt" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Cash Recipt</title>
    <link href="css/main.css" type="text/css" rel="stylesheet"/>
    <script type="text/javascript"language="javascript" src="javascript/popupcalender.js"></script>
		<%--<script language="javascript" src="javascript/permission.js"></script>
		<script language="javascript" src="javascript/datevalidation.js"></script>--%>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script  type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/cash_recipt.js"></script>
		  <script language="javascript"  type="text/javascript" src="javascript/datevalidation.js"></script>
		
		

</head>
<body onload="document.getElementById('btnmodify').disabled=true;document.getElementById('txtbank').disabled=true;" style="margin:0px 0px 0px 0px">
    <form id="form1" runat="server" style="margin:0px 0px 0px 0px">
    <div>
   <table border="0" cellpadding="0" cellspacing="0" >
    <tr >
    <td colspan="0"><uc1:topbar id="Topbar1" runat="server" Text="Cash Recipt"></uc1:topbar></td>
    </tr>
    
   <tr>
   <td>
   <table align="center" height="80px">
     <tr>
     <td><asp:Label ID="lbladtype" runat="server" CssClass="TextField">Booking ID<font color="red">*</font></asp:Label></td>
     <td><asp:TextBox  id="txtbookingid" runat="server" CssClass="btext1"
							MaxLength="50"></asp:TextBox></td>
							<td align="right" style="height: 24px"><asp:button id="btnsubmit" runat="server" CssClass="button1" Text="Submit" ></asp:button>
             <asp:Button ID="btnclear" runat="server" CssClass="button1" Text="Clear" />
              </td>
              <td><asp:Label ID="lblbank" runat="server" CssClass="TextField">Bank<font color="red">*</font></asp:Label></td>
     <td><asp:DropDownList  id="txtbank" runat="server" CssClass="btext1" ></asp:DropDownList></td>
     </tr>
     
     </table>
    
    
    <table border="0" cellpadding="0" cellspacing="0" align=center><tr><td align=center>
        <asp:Label ID="lbldoctype" runat="server" CssClass="TextField"></asp:Label>
        </td></tr></table>
    <table width="1000px"; align="center" style="margin:15px 0px 0px 0px"><tr><td align="center">
     <div id="maintbl" runat="server">
    <table>    
<tr>
    <td align="left"><asp:Label ID="lblagency" runat="server" CssClass="TextField" ></asp:Label></td>
    <td> 
        <asp:TextBox ID="txtagency" CssClass="btext1_BOOKADI" runat="server" TextMode="MultiLine" style="height:60;color:Black ;"></asp:TextBox>
        </td>
        
        <td style="width:20px"></td>    
        
   
   <td align="left"><asp:Label ID="lblexecutivename" runat="server" CssClass="TextField" ></asp:Label></td>
    <td>
        <asp:TextBox ID="txtexecutivename" CssClass="btext1_BOOKADI" runat="server"  TextMode="MultiLine" style="height:60" ></asp:TextBox>
        </td>     
        
        
        
        

    <td style="width:20px"></td>
 

    <td align="left"><asp:Label ID="lblcardrate" runat="server" CssClass="TextField" ></asp:Label></td>
    <td>
        <asp:TextBox ID="txtcardrate" CssClass="btext1numeric_new" runat="server"></asp:TextBox></td>       
        
</tr>

<tr>
    <td align="left"><asp:Label ID="lblclient" runat="server" CssClass="TextField" ></asp:Label></td>
    <td> 
         <asp:TextBox ID="txtclient" CssClass="btext1_BOOKADI" runat="server" TextMode="multiLine" style="height:60"></asp:TextBox>
         </td>
        
    <td style="width:5px"></td>
    <td align="left"><asp:Label ID="lblpackage" runat="server" CssClass="TextField"></asp:Label></td>
    <td>
        <asp:TextBox ID="txtpackage" CssClass="btext1_BOOKADI" runat="server" TextMode="MultiLine" style="height:60"></asp:TextBox></td>

    <td style="width:20px"></td>
    <td align="left"><asp:Label ID="lblcardamount" runat="server" CssClass="TextField"></asp:Label></td>
    <td>
        <asp:TextBox ID="txtcardamount" CssClass="btext1numeric_new" runat="server"></asp:TextBox>
        </td>               
</tr>

<tr>
    <td align="left"><asp:Label ID="lblpaymode" runat="server" CssClass="TextField" ></asp:Label></td>
    <td>
        <asp:TextBox ID="txtpaymode" CssClass="btext1_BOOKADI" runat="server"></asp:TextBox>
        </td>

    <td style="width:5px"></td>        
    <td align="left"><asp:Label ID="lblpublichdate" runat="server" CssClass="TextField" Width="75px" ></asp:Label></td>
    <td>
        <asp:TextBox ID="txtpublishdate" CssClass="btext1_BOOKADI" runat="server"></asp:TextBox></td>

    <td style="width:20px"></td>
    <td align="left"><asp:Label ID="lblagreedrate" runat="server" CssClass="TextField"></asp:Label></td>
    <td>
        <asp:TextBox ID="txtagreedrate" CssClass="btext1numeric_new" runat="server"></asp:TextBox>
        </td>
             
</tr>

<tr>
    <td align="left"><asp:Label ID="lblrono" runat="server" CssClass="TextField" ></asp:Label></td>
    <td >
        <asp:TextBox ID="txtrono" CssClass="btext1numeric_new" runat="server"></asp:TextBox></td>
        
    <td style="width:5px"></td>
    <td align="left"><asp:Label ID="lblnoofinsertion" runat="server" CssClass="TextField"></asp:Label></td>
    <td>
        <asp:TextBox ID="txtnoofinsertion" CssClass="btext1numeric_new" runat="server"></asp:TextBox>
        </td>

    <td style="width:20px"></td>
    <td align="left"><asp:Label ID="lblagreedamount" runat="server" CssClass="TextField"></asp:Label></td>
    <td>
        <asp:TextBox ID="txtagreedamount" CssClass="btext1numeric_new" runat="server"></asp:TextBox>
        </td>          
                
</tr>

<tr>
    <td align="left"><asp:Label ID="lblrostatus" runat="server" CssClass="TextField" ></asp:Label></td>
    <td>
        <asp:TextBox ID="txtrostatus"  CssClass="btext1_BOOKADI" runat="server"></asp:TextBox>
        </td>
       
    <td style="width:5px"></td>
    <td align="left"><asp:Label ID="lblpaid" runat="server" CssClass="TextField"></asp:Label></td>
    <td>
        <asp:TextBox ID="txtpaid" CssClass="btext1numeric_new" runat="server"></asp:TextBox>
        </td>
        
    <td style="width:20px"></td>
    <td align="left"><asp:Label ID="lbldiscount" runat="server" CssClass="TextField" ></asp:Label></td>
    <td>
        <asp:TextBox ID="txtdiscount" CssClass="btext1numeric_new1" runat="server"></asp:TextBox><font >%</font>
        <asp:TextBox ID="txtdiscountamt" CssClass="btext1numeric_new1" runat="server"></asp:TextBox>
        </td> 
</tr>

<tr>


           

  
    <td align="left" style="color:Black"><asp:Label ID="lbluom" runat="server" CssClass="TextField"  ></asp:Label></td>
    <td style="color:Lime;">
        <asp:TextBox ID="txtuom"  CssClass="btext1_BOOKADI"  runat="server"></asp:TextBox></td>
        
        
        
    <td style="width:20px"></td>
    <td align="left"><asp:Label ID="lblcontractname" runat="server" CssClass="TextField"></asp:Label></td>
    <td>
        <asp:TextBox ID="txtcontractname" CssClass="btext1_BOOKADI" runat="server"></asp:TextBox>
        </td>

    <td style="width:20px"></td>
    <td align="left"><asp:Label ID="lblPagePrem" runat="server" CssClass="TextField"></asp:Label></td>
    <td >
        <asp:TextBox ID="txtPagePrem" CssClass="btext1numeric_new1" runat="server"></asp:TextBox><font class=TextField>%</font>
        <asp:TextBox ID="txtPagePremamt" CssClass="btext1numeric_new1" runat="server"></asp:TextBox>
        </td>  
    
</tr>

<tr>
    <td align="left"><asp:Label ID="lbloutstanding" runat="server" CssClass="TextField" ></asp:Label></td>
    <td>
        <asp:TextBox ID="txtoutstanding" CssClass="btext1numeric_new" runat="server"></asp:TextBox></td>

    <td style="width:5px"></td>        
    <td align="left"><asp:Label ID="lblheight" runat="server" CssClass="TextField" ></asp:Label></td>
    <td><font Class="TextField">H&nbsp;</font>
        <asp:TextBox ID="txtheight" CssClass="btext1numeric_new" style="width:45px" runat="server" ></asp:TextBox>
        <font Class="TextField">&nbsp;W&nbsp;</font>
        <asp:TextBox ID="txtwidth" style="width:45px;" CssClass="btext1numeric_new" runat="server" ></asp:TextBox></td>

    <td style="width:20px"></td>
    <td align="left"><asp:Label ID="lblpositionpremium" runat="server" CssClass="TextField"></asp:Label></td>
    <td >
        <asp:TextBox ID="txtpositionpremium" CssClass="btext1numeric_new1" runat="server"></asp:TextBox><font class=TextField>%</font>
        <asp:TextBox ID="txtpositionpremiumamt" CssClass="btext1numeric_new1" runat="server"></asp:TextBox>
        </td>    
</tr>

<tr>

   <td align="left"><asp:Label ID="lblratecode" CssClass="TextField" runat="server"></asp:Label></td>
    <td>
        <asp:TextBox ID="txtratecode" CssClass="btext1_BOOKADI" runat="server"></asp:TextBox>
        </td>

    <td style="width:5px"></td>
    <td align="left"><asp:Label ID="lbllines" runat="server" CssClass="TextField" ></asp:Label></td>
    <td>
        <asp:TextBox ID="txtlines" CssClass="btext1numeric_new" runat="server"></asp:TextBox>
        </td>

    <td style="width:20px"></td>
    <td align="left"><asp:Label ID="lblspecialdiscount" runat="server" CssClass="TextField"></asp:Label></td>
    <td>
        <asp:TextBox ID="txtspecialdiscount" CssClass="btext1numeric_new1" runat="server"></asp:TextBox><font class=TextField>%</font>
        <asp:TextBox ID="txtspecialdiscountamt" CssClass="btext1numeric_new1" runat="server"></asp:TextBox>
        </td> 
</tr>

<tr>
    <td align="left"><asp:Label ID="lblbookingtype" runat="server" CssClass="TextField" ></asp:Label></td>
    <td>
        <asp:TextBox ID="txtbookingtype" CssClass="btext1_BOOKADI" runat="server"></asp:TextBox></td>

    <td style="width:5px"></td>
    <td style="width:128px" align="left"><asp:Label ID="lblpageposition" runat="server" CssClass="TextField"></asp:Label></td>
    <td>
        <asp:TextBox ID="txtpageposition" CssClass="btext1_BOOKADI" runat="server"></asp:TextBox>
        </td>

    <td style="width:20px"></td>
    <td align="left"><asp:Label ID="lblspacediscount" runat="server" CssClass="TextField"></asp:Label></td>
    <td>
        <asp:TextBox ID="txtspacediscount" CssClass="btext1numeric_new1" runat="server"></asp:TextBox><font class=TextField>%</font>
        <asp:TextBox ID="txtspacediscountamt" CssClass="btext1numeric_new1" runat="server"></asp:TextBox>
        </td>         
                
</tr>

<tr>
    <td align="left"><asp:Label ID="lblcolourtype" runat="server" CssClass="TextField" ></asp:Label></td>
    <td>
        <asp:TextBox ID="txtcolourtype" CssClass="btext1_BOOKADI" runat="server"></asp:TextBox>
        </td>

    <td style="width:5px"></td>
    <td align="left"><asp:Label ID="lblpositionpre" runat="server" CssClass="TextField"></asp:Label></td>
    <td>
        <asp:TextBox ID="txtpositionpre" CssClass="btext1_BOOKADI" runat="server"></asp:TextBox>
        </td>
        
    <td style="width:20px"></td>
    <td align="left"><asp:Label ID="lblSumAmt" runat="server" CssClass="TextField"></asp:Label></td>
    <td>
        <asp:TextBox ID="txtSumAmt" CssClass="btext1numeric_new" runat="server"></asp:TextBox>
        </td>
</tr>

<tr>
    <td align="left"><asp:Label ID="lbladcategory" runat="server" CssClass="TextField" ></asp:Label></td>
    <td>
        <asp:TextBox ID="txtadcategory" CssClass="btext1_BOOKADI" runat="server"></asp:TextBox>
        </td>
        
    <td style="width:5px"></td>
    <td align="left"><asp:Label ID="lblarea" runat="server" CssClass="TextField" ></asp:Label></td>
    <td>
        <asp:TextBox ID="txtarea" CssClass="btext1_BOOKADI" runat="server"></asp:TextBox>
        </td>

    <td style="width:20px"></td>
    <td align="left"><asp:Label ID="lblspecialcharge" runat="server" CssClass="TextField"></asp:Label></td>
    <td>
        <asp:TextBox ID="txtspecialcharge" CssClass="btext1numeric_new" runat="server"></asp:TextBox>
        </td> 
</tr>

<tr>
    <td align="left"><asp:Label ID="lbladsubcat1" runat="server" CssClass="TextField" ></asp:Label></td>
    <td>
        <asp:TextBox ID="txtadsubcat1" CssClass="btext1_BOOKADI" runat="server"></asp:TextBox>
        </td>

    <td style="width:5px"></td>
    <td align="left"><asp:Label ID="lblschemetype" runat="server" CssClass="TextField"></asp:Label></td>
    <td>
        <asp:TextBox ID="txtschemetype" CssClass="btext1_BOOKADI" runat="server"></asp:TextBox>
        </td>
        
    <td style="width:20px"></td>
    <td align="left"><asp:Label ID="lblgrossamt" runat="server" CssClass="TextField" ></asp:Label></td>
    <td>
        <asp:TextBox ID="txtgrossamt" CssClass="btext1numeric_new" runat="server"></asp:TextBox>
        </td>
</tr>

<tr>


    <td align="left"><asp:Label ID="lbladsubcat3" runat="server" CssClass="TextField"></asp:Label></td>
    <td>
        <asp:TextBox ID="txtadsubcat3" CssClass="btext1_BOOKADI" runat="server" ></asp:TextBox>
        </td>
        
        
    <td style="width:5px"></td>
    <td align="left"><asp:Label ID="lbladsubcat2" runat="server" CssClass="TextField" ></asp:Label></td>
    <td>
        <asp:TextBox ID="txtadsubcat2" CssClass="btext1_BOOKADI" runat="server"></asp:TextBox>
        </td>

 

    <td style="width:20px"></td>
    <td align="left"><asp:Label ID="lblagtradediscount" runat="server" CssClass="TextField"></asp:Label></td>
    <td>
        <asp:TextBox ID="txtagtradediscount" CssClass="btext1numeric_new1" runat="server"></asp:TextBox><font class=TextField>%</font>
        <asp:TextBox ID="txtagtradediscountamt" CssClass="btext1numeric_new1" runat="server"></asp:TextBox>
        </td> 
</tr>

<tr>


 <td align="left"><asp:Label ID="lbladsubcat4" runat="server" CssClass="TextField" ></asp:Label></td>
    <td>
        <asp:TextBox ID="txtadsubcat4" CssClass="btext1_BOOKADI" runat="server"></asp:TextBox>
        </td>


<td style="width:5px"></td>
    <td align="left"><asp:Label ID="Lbeyecater_prem" runat="server" CssClass="TextField"  Text="Eye Catcher Prem"></asp:Label></td>
    <td>
        <asp:TextBox ID="txt_eyecaterprem" CssClass="btext1numeric_new" runat="server"></asp:TextBox>
        </td>
    <td></td>
    
    
    <td align="left"><asp:Label ID="lbladdagecomm" runat="server" CssClass="TextField"></asp:Label></td>
    <td>
        <asp:TextBox ID="txtaddagecomm" CssClass="btext1numeric_new1" runat="server"></asp:TextBox><font class=TextField>%</font>
        <asp:TextBox ID="txtaddagecommamt" CssClass="btext1numeric_new1" runat="server"></asp:TextBox>
        </td> 
</tr>

<tr>
     <td align="left"><asp:Label ID="Lbeyecater" runat="server" CssClass="TextField" Text="Eye Catcher" ></asp:Label></td>
    <td>
        <asp:TextBox ID="txt_eyecater" CssClass="btext1numeric_new" runat="server"></asp:TextBox>
        </td>
    <td></td>

    <td style="width:5px"></td>
    <td></td>
    <td></td>


    <td align="left"><asp:Label ID="lblbillamount" runat="server" CssClass="TextField"></asp:Label></td>
    <td>
        <asp:TextBox ID="txtbillamount" CssClass="btext1numeric_new" runat="server"></asp:TextBox>
        </td>
</tr>
<tr>
 
 
 <td align="left"><asp:Label ID="lblretainername" runat="server" CssClass="TextField" ></asp:Label></td>
    <td>
        <asp:TextBox ID="txtretainername" CssClass="btext1_BOOKADI" runat="server" TextMode="MultiLine" style="height:60"></asp:TextBox>
        </td>
 <td></td>
  <td></td>
   <td></td>
   
    
     <td></td>
    <td align="left"><asp:Label ID="lblretainercommission" runat="server" CssClass="TextField"></asp:Label></td>
    
    <td>
        <asp:TextBox ID="txtretainercommission" CssClass="btext1numeric_new1" runat="server"></asp:TextBox><font class=TextField>%</font>
        <asp:TextBox ID="txtretainercommissionamt" CssClass="btext1numeric_new1" runat="server"></asp:TextBox>
        </td>
        
    
</tr>



<tr><td colspan='8' align="center"><table> <tr><td><asp:Label ID="lblpaymode123"  style="display:block;" runat="server" CssClass="TextField">Pay Mode</asp:Label></td><td>
         <asp:DropDownList ID="drppaymode" runat="server" CssClass="dropdown" 
              style="display:block;">
         </asp:DropDownList>
         </td></tr>  </table></td></tr>

<tr><td colspan='8'>
    <table align="center" style="vertical-align:top;" width="60%">

<%--<td>  <asp:Label ID="lblcashrecieved0" style="display:none" runat="server" 
                 CssClass="TextField" ></asp:Label></td><td>
             <asp:TextBox ID="drpcashrecieved0" style="display:none"  onkeypress="return notchar2(event);" 
                 runat="server" CssClass="btext1">
                                         </asp:TextBox></td>--%>


     
        <tr id="cashrecvd" style="display:none">
            <td>
                <asp:Label ID="Label3" runat="server" CssClass="TextField" Text="Cash Discount"></asp:Label>
            </td>
            <td id="Td2" runat="server" >
                <asp:TextBox ID="txtcashdiscount" runat="server" CssClass="btext1">
                                         </asp:TextBox>
            </td>
            <td id="Td1" runat="server">
                <asp:Label ID="lblcashrecieved" runat="server" CssClass="TextField"></asp:Label>
            </td>
            <td runat="server">
                <asp:TextBox ID="drpcashrecieved" runat="server" CssClass="btext1" 
                    >
                                         </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td id="tdcarname" style="display:none" valign="top">
                <asp:Label ID="lbcardname" runat="server" CssClass="TextField"></asp:Label>
            </td>
            <td id="tdtxtcarname" align="left" style="display:none" valign="top">
                <asp:TextBox ID="txtcardname" runat="server" CssClass="btext1"></asp:TextBox>
            </td>
            <td id="tdtype" style="display:none" valign="top">
                <asp:Label ID="lbtype" runat="server" CssClass="TextField"></asp:Label>
            </td>
            <td id="tddrptyp" style="display:none">
                <asp:DropDownList ID="drptype" runat="server" CssClass="dropdown">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td id="tdexdat" style="display:none" valign="top">
                <asp:Label ID="lbexdate" runat="server" CssClass="TextField"></asp:Label>
            </td>
            <td id="tdtxtexdat" align="left" style="display:none; " valign="top">
                <asp:DropDownList ID="drpmonth" runat="server" CssClass="drpsmall">
                    <asp:ListItem Selected="True" Value="0">Month</asp:ListItem>
                    <asp:ListItem Value="1">Jan</asp:ListItem>
                    <asp:ListItem Value="2">Feb</asp:ListItem>
                    <asp:ListItem Value="3">Mar</asp:ListItem>
                    <asp:ListItem Value="4">Apr</asp:ListItem>
                    <asp:ListItem Value="5">May</asp:ListItem>
                    <asp:ListItem Value="6">Jun</asp:ListItem>
                    <asp:ListItem Value="7">Jul</asp:ListItem>
                    <asp:ListItem Value="8">Aug</asp:ListItem>
                    <asp:ListItem Value="9">Sep</asp:ListItem>
                    <asp:ListItem Value="10">Oct</asp:ListItem>
                    <asp:ListItem Value="11">Nov</asp:ListItem>
                    <asp:ListItem Value="12">Dec</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="drpyear" runat="server" CssClass="drpsmall">
                    <asp:ListItem Selected="true" Value="0">Year</asp:ListItem>
                    <asp:ListItem Value="2008">08</asp:ListItem>
                    <asp:ListItem Value="2009">09</asp:ListItem>
                    <asp:ListItem Value="2010">10</asp:ListItem>
                    <asp:ListItem Value="2011">11</asp:ListItem>
                    <asp:ListItem Value="2012">12</asp:ListItem>
                     <asp:ListItem Value="2012">13</asp:ListItem>
                      <asp:ListItem Value="2012">14</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td id="tdcardno" style="display:none" valign="top">
                <asp:Label ID="lbcardno" runat="server" CssClass="TextField"></asp:Label>
            </td>
            <td id="tdtxtcarno" style="display:none" valign="top">
                <asp:TextBox ID="txtcardno" runat="server" CssClass="btext1" MaxLength="20"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td id="tdchqno" runat="server" style="display:none">
                <asp:Label ID="lbchqno" runat="server" CssClass="TextField"></asp:Label>
            </td>
            <td id="tdtextchqno" runat="server" style="display:none">
                <asp:TextBox ID="ttextchqno" runat="server" CssClass="btext1" MaxLength="20"></asp:TextBox>
            </td>
            <td id="tdchqamt" runat="server" style="display:none">
                <asp:Label ID="lbchqamt" runat="server" CssClass="TextField"></asp:Label>
            </td>
            <td id="tdtextchqamt" align="left" style="display:none" valign="top">
                <asp:TextBox ID="ttextchqamt" runat="server" CssClass="btext1"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td id="tdchqdate" style="display:none">
                <asp:Label ID="lbchqdate" runat="server" CssClass="TextField"></asp:Label>
            </td>
            <td id="tdtextchqdate" style="display:none">
                <asp:TextBox ID="ttextchqdate" runat="server" CssClass="btext1"></asp:TextBox>
            </td>
            <td id="tdbankname" style="display:none">
                <asp:Label ID="lbbankname" runat="server" CssClass="TextField"></asp:Label>
            </td>
            <td id="tdtextbankname" style="display:none">
                <asp:TextBox ID="ttextbankname" runat="server" CssClass="btext1"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
                                   <%-- <tr>  <td id="tdourbank" style="display:none">
                                        <asp:Label ID="lbourbank"  runat="server" Text="Our Bank" CssClass="TextField"></asp:Label></td>
                                       <td id="tdtextourbank" style="display:none">
                                         <asp:DropDownList ID="drpourbank"  runat="server" CssClass="dropdownforbook"></asp:DropDownList></td>
                                 </tr>--%>
                                        
                                      

     
     
     
     
     
     
     
     
     
     
     
     
     
     
     
     
     
     
     
     
     
     
     
     
     
     
     
          </table>
    <td></tr>

  <tr>
        <td align="right" colspan="2" >  
        
       
        <asp:Button ID="btnmodify" runat="server" CssClass="button1" Width=100px  Text="Cash Received" />
        
        
    </td>
        </tr>
        
      </table>
      </div>
        </td></tr></table>
      </td>
      </tr>
    </table>
    </div>
    <input id="hiddencomcode" type="hidden" size="1" name="hiddencomcode" runat="server"/>
			<input id="hiddenuserid" type="hidden" size="1" name="Hidden1" runat="server"/> 
			<input id="hiddendateformat" type="hidden" size="1" name="Hidden2" runat="server"/>
			<input id="hiddencompcode" type="hidden" size="1" name="hiddencompcode" runat="server"/>
			<input id="hiddenusername" type="hidden" size="2" name="Hidden1" runat="server"/>
			<input id="hiddenauto" type="hidden" name="hiddenuserid" runat="server" />
			<input id="hiddenbookingid" type="hidden" name="hiddenbookingid" runat="server" />
			<input id="hiddenrowcount" type="hidden" name="hiddenrowcount" runat="server" />
			<input id="hiddenadtype" type="hidden" name="hiddenadtype" runat="server" />
			<input id="hiddenid" type="hidden" name="hiddenid" runat="server" />
			<input id="hiddenmodify" value="0" type="hidden" name="hiddenmodify" runat="server" />
			<input id="hiddenrefresh" value="0" type="hidden" name="hiddenrefresh" runat="server" />
			<input id="hiddenuomdesc" value="0" type="hidden" name="hiddenuomdesc" runat="server" />
			<input id="hiddenbranch" type="hidden" size="1" name="hiddenbranch" runat="server"/>
			
			<input id="hdnexecutivetxt" type="hidden" size="1" name="hiddenbranch1" runat="server"/>
			<input id="hiddenserverip" type="hidden" size="1" name="hiddenbranch1" runat="server"/>
			
			<input id="hiddenbk_audit" type="hidden" size="1" name="hiddenbranch" runat="server"/>
    </form>
</body>
</html>
