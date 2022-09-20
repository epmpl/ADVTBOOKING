<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Changeagency.aspx.cs" Inherits="Changeagency" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar.ascx"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Change Agency</title>
    <script>
      agnf2 = '<%=ConfigurationManager.AppSettings["agencyf2"].ToString()%>'
    </script>
    
    
    <link href="css/main.css" type="text/css" rel="stylesheet"/>
     <script type="text/javascript"language="javascript" src="javascript/changeagency.js"></script>
</head>
<body  leftMargin="0" topmargin=0>
 
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
     <div id="div1" style="position: absolute; top: 0px; left: 0px; border: none; display: none;
            z-index: 1; " >
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:ListBox ID="lstagency" Width="820px" Height="150px" runat="server" CssClass="btextlistagen">
                        </asp:ListBox></td>
                </tr>
            </table>
        </div>
    <div>
    <table id="OuterTable" width="980" align="center" border="0" cellpadding="0" cellspacing="0">
    <tr >
    <td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Ad Booking Audit"></uc1:topbar></td>
    </tr>
    
   
  	<table border="0" width="100%" cellpadding="0" cellspacing="0" style="width:auto;margin:15px 30px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Change Agency</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>  
    
    
    
    <table><tr><td align="right" width="500px"><b>
    <asp:Label ID="lblrefno" runat="server" CssClass="TextField" style="font-family:Verdana;font-size:12px">Enter Refrence No./Booking id/RoNo</asp:Label></td>
    <td><asp:TextBox ID="txt_refno" runat="server" CssClass="btext1" ></asp:TextBox></td>
    <td>
    <asp:button id="btnsubmit" runat="server" CssClass="button1" Text="Submit"></asp:button>
        </td></tr>
    </table>
    
    
     <table width="300px"   align="center"  style="border: 1px solid #0066FF; margin-top:0px; caption-side: top; v-align:top;">
     
    
<tr><td align="right">
<asp:Label ID="lbagency" runat="server" CssClass="TextField" ></asp:Label>
</td><td align="right" colspan="1"><asp:TextBox ID="txt_agency" runat="server" CssClass="btext1" MaxLength="50" onkeyup="javascript:return f2query(event);" ></asp:TextBox>
</td>

<td>
        <asp:button id="btnupdate" runat="server" CssClass="button1" Text="Update"></asp:button>
    </td>
</tr>

 
     </table>
    
    
    
    
    <table>
    <tr>
    <td align="center">
     <div id="maintbl" runat="server">
        <table>    
<tr>
    <td align="left"><asp:Label ID="lblagency" runat="server" CssClass="TextField" ></asp:Label></td>
    <td> 
        <asp:TextBox ID="txtagency" CssClass="btext1_BOOKADI" runat="server" TextMode="MultiLine" style="height:40px"></asp:TextBox>
       </td>

    <td style="width:5px"></td>
    <td align="left" style="color:Black"><asp:Label ID="lblagencyaddres" runat="server" 
            CssClass="TextField" ></asp:Label></td>
    <td style="color:Lime;">
        <asp:TextBox ID="txtagencyadders" CssClass="btext1_BOOKADI" runat="server" 
            TextMode="MultiLine" style="height:40px"></asp:TextBox>
       </td>

    <td style="width:20px"></td>
    <td align="left"><asp:Label ID="lblcardrate" runat="server" CssClass="TextField" ></asp:Label></td>
    <td>
        <asp:TextBox ID="txtcardrate" CssClass="btext1numeric_new" runat="server"></asp:TextBox></td>       
        
</tr>

<tr>
    <td align="left"><asp:Label ID="lblclient" runat="server" CssClass="TextField" ></asp:Label></td>
    <td>
         <asp:TextBox ID="txtclient" CssClass="btext1_BOOKADI" runat="server" TextMode="multiLine" style="height:40px"></asp:TextBox>
        </td>
        
    <td style="width:5px"></td>
    <td align="left"><asp:Label ID="lblpackage" runat="server" CssClass="TextField"></asp:Label></td>
    <td>
        <asp:TextBox ID="txtpackage" CssClass="btext1_BOOKADI" runat="server" TextMode="MultiLine" style="height:40px"></asp:TextBox></td>

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
        <asp:TextBox ID="txtrono" CssClass="btext1numeric_new" runat="server"></asp:TextBox>
        </td>
        
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
        <asp:TextBox ID="txtdiscount" CssClass="btext1numeric_new1" runat="server"></asp:TextBox><font class=TextField>%</font>
        <asp:TextBox ID="txtdiscountamt" CssClass="btext1numeric_new1" runat="server"></asp:TextBox>
   </td> 
</tr>

<tr>
    <td align="left"><asp:Label ID="lblexecutivename" runat="server" CssClass="TextField" ></asp:Label></td>
    <td>
        <asp:TextBox ID="txtexecutivename" CssClass="btext1_BOOKADI" runat="server" style="height:40px;" TextMode="multiLine" ></asp:TextBox>
        </td>
        
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
    <td align="left"><asp:Label ID="lblretainername" runat="server" CssClass="TextField" ></asp:Label></td>
    <td>
        <asp:TextBox ID="txtretainername" CssClass="btext1_BOOKADI" runat="server" style="height:40px" TextMode="MultiLine"></asp:TextBox>
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
    <td align="left"><asp:Label ID="lblpageposition" runat="server" CssClass="TextField"></asp:Label></td>
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
    <td align="left"><asp:Label ID="lbladsubcat2" runat="server" CssClass="TextField" ></asp:Label></td>
    <td>
        <asp:TextBox ID="txtadsubcat2" CssClass="btext1_BOOKADI" runat="server"></asp:TextBox>
        </td>

    <td style="width:5px"></td>
    <td align="left"><asp:Label ID="lblratecode" CssClass="TextField" runat="server"></asp:Label></td>
    <td>
        <asp:TextBox ID="txtratecode" CssClass="btext1_BOOKADI" runat="server"></asp:TextBox>
        </td>

    <td style="width:20px"></td>
    <td align="left"><asp:Label ID="lblagtradediscount" runat="server" CssClass="TextField"></asp:Label></td>
    <td>
        <asp:TextBox ID="txtagtradediscount" CssClass="btext1numeric_new1" runat="server"></asp:TextBox><font class=TextField>%</font>
        <asp:TextBox ID="txtagtradediscountamt" CssClass="btext1numeric_new1" runat="server"></asp:TextBox>
       </td> 
</tr>

<tr>
    <td align="left"><asp:Label ID="lbladsubcat3" runat="server" CssClass="TextField"></asp:Label></td>
    <td>
        <asp:TextBox ID="txtadsubcat3" CssClass="btext1_BOOKADI" runat="server"></asp:TextBox>
        </td>

    <td style="width:5px"></td>
    <td align="left"><asp:Label ID="lblbremark" runat="server" CssClass="TextField"></asp:Label></td>
    <td><asp:textbox ID="txtbillremark" runat="server" Enabled="false" CssClass="btext1_BOOKADI"></asp:textbox></td>
    
    <td style="width:20px"></td>
    <td align="left"><asp:Label ID="lbladdagecomm" runat="server" CssClass="TextField"></asp:Label></td>
    <td>
        <asp:TextBox ID="txtaddagecomm" CssClass="btext1numeric_new1" runat="server"></asp:TextBox><font class=TextField>%</font>
        <asp:TextBox ID="txtaddagecommamt" CssClass="btext1numeric_new1" runat="server"></asp:TextBox>
        </td> 
</tr>
<tr>
   <td align="left"><asp:Label ID="lbladsubcat4" runat="server" CssClass="TextField" ></asp:Label></td>
    <td>
        <asp:TextBox ID="txtadsubcat4" CssClass="btext1_BOOKADI" runat="server"></asp:TextBox>
        </td>

    <td style="width:5px"></td>
    <td align="left"><asp:Label ID="lblcaption" runat="server" CssClass="TextField"></asp:Label></td>
    <td><asp:TextBox ID="txtcaption" runat="server" ReadOnly="true" CssClass="btext1_BOOKADI"></asp:TextBox></td>
    
    <td style="width:20px"></td>
    <td align="left"><asp:Label ID="lbltranslationcrg" runat="server" CssClass="TextField"></asp:Label></td>
    <td>
        <asp:TextBox ID="txttransper" ReadOnly="true" CssClass="btext1numeric_new1" runat="server"></asp:TextBox><font class=TextField>%</font>
        <asp:TextBox ID="txttranamt" ReadOnly="true" CssClass="btext1numeric_new1" runat="server"></asp:TextBox>
        </td> 
</tr>
<tr>
     <td align="left"><asp:Label ID="Lbeyecater" runat="server" CssClass="TextField" Text="Eye Catcher" ></asp:Label></td>
    <td>
        <asp:TextBox ID="txt_eyecater" CssClass="btext1numeric_new" ReadOnly="true" runat="server"></asp:TextBox>
        </td>
    <td></td>
    
    <td align="left"><asp:Label ID="Lbeyecater_prem" runat="server" CssClass="TextField"  Text="Eye CatcherPrem"></asp:Label></td>
    <td>
        <asp:TextBox ID="txt_eyecaterprem" ReadOnly="true" CssClass="btext1numeric_new" runat="server"></asp:TextBox>
    </td>

    <td></td>
    <td align="left"><asp:Label ID="lblbillamount" runat="server" CssClass="TextField"></asp:Label></td>
    <td>
        <asp:TextBox ID="txtbillamount" CssClass="btext1numeric_new" runat="server"></asp:TextBox>
        </td>
</tr>
<tr>
   <td align="left"><asp:Label ID="lblboxcharg" runat="server" CssClass="TextField" ></asp:Label></td>
    <td>
        <asp:TextBox ID="txtboxcrg" CssClass="btext1numeric_new" ReadOnly="true" runat="server"></asp:TextBox>
        </td>
    <td></td>
    
    <td align="left"><asp:Label ID="lbboxcharges" runat="server" CssClass="TextField" ></asp:Label></td>
    <td>
        <asp:TextBox ID="txtboxcharges" CssClass="btext1numeric_new" ReadOnly="true" runat="server"></asp:TextBox>
        </td>
    <td></td>
    <td align="left"><asp:Label ID="lblretainercommission" runat="server" CssClass="TextField"></asp:Label></td>
    
    <td>
        <asp:TextBox ID="txtretainercommission" CssClass="btext1numeric_new1" runat="server"></asp:TextBox><font class=TextField>%</font>
        <asp:TextBox ID="txtretainercommissionamt" CssClass="btext1numeric_new1" runat="server"></asp:TextBox>
      </td>
    
</tr>
<tr>
    <td align="left"><asp:Label ID="lbluom" runat="server" CssClass="TextField"  ></asp:Label></td>
    <td>
        <asp:TextBox ID="txtuom"  CssClass="btext1numeric_new"  runat="server"></asp:TextBox></td>
    <td></td>
    
    <td style="width:30px"></td>
    <td></td>
    <td align="left" ></td>   
    
   
   
    
</tr>
<tr>  <td colspan='20'>
    <asp:button id="btnexit" runat="server" CssClass="button1" Text="Exit"></asp:button>
        </td>
</tr>











      </table>
        </div>
        </td></tr></table>
    
    </table>
    </div>
    
    <input id="hiddencompcode" type="hidden" size="1" name="hiddencompcode" runat="server"/>
    <input id="hiddenusername" type="hidden" size="1" name="hiddenusername" runat="server"/>
    	<input id="hiddendateformat" type="hidden" size="1" name="Hidden2" runat="server"/>
    	<input id="hiddenuomdesc" value="0" type="hidden" name="hiddenuomdesc" runat="server" />
    	<input id="hidden1" value="0" type="hidden" name="hiddenrefresh" runat="server" />
    	<input id="hiddenrefresh" value="0" type="hidden" name="hiddenrefresh" runat="server" />
    	     <input id="hiddenuserid" type="hidden" size="1" name="Hidden1" runat="server" />
    	<input id="hiddenadtype" type="hidden" name="hiddenadtype" runat="server" />
    <input id="Hiddenagencycode" type="hidden" name="hidattach1" runat="server" />
    <input id="hdncodesubcode" type="hidden" name="hdncodesubcode" runat="server" />
    <input id="hdncode" type="hidden" name="hdncode" runat="server" />
    </form>
</body>
</html>

