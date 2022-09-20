<%@ Page Language="C#" AutoEventWireup="true" CodeFile="external_cash_recipt.aspx.cs" Inherits="external_cash_recipt" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>External Cash Receipt</title>
      <link href="css/main.css" type="text/css" rel="stylesheet"/>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script  type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/external_cash_receipt.js"></script>
		 
</head>
<body onload="document.getElementById('btnmodify').disabled=true;" style="margin:0px 0px 0px 0px">
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
							<td colspan="4" align="right" style="height: 24px"><asp:button id="btnsubmit" runat="server" CssClass="button1" Text="Submit" ></asp:button>
             <asp:Button ID="btnclear" runat="server" CssClass="button1" Text="Clear" />
              </td>
     </tr>
     
    </table>
    <table border="0" cellpadding="0" cellspacing="0" align=center><tr><td align=center><asp:Label ID="lbldoctype" runat="server" CssClass="TextField" ></asp:Label></td></tr></table>
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
  <tr align="center">
  <td></td><td></td>
  <td><asp:Label ID="lblreceipt" runat="server" CssClass="TextField" Text="Enter Receipt No" style="font-weight:bold"></asp:Label></td>
  <td> <asp:TextBox ID="txtreceipt" MaxLength="15" CssClass="btext1_BOOKADI" runat="server" ></asp:TextBox></td>
        <td align="right" >  
        
       
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
