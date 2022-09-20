<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cash_rcptformult.aspx.cs" Inherits="cash_rcptformult"  EnableEventValidation="false"%>

<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Cash Recipt For Multiple Booking Id</title>
    <link href="css/main.css" type="text/css" rel="stylesheet"/>
    <script type="text/javascript"language="javascript" src="javascript/popupcalender.js"></script>
		<%--<script language="javascript" src="javascript/permission.js"></script>
		<script language="javascript" src="javascript/datevalidation.js"></script>--%>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script  type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/cash_rcptmult.js"></script>
		  <script language="javascript"  type="text/javascript" src="javascript/datevalidation.js"></script>
		 <script language="javascript"  type="text/javascript" src="javascript/datevalidation.js"></script>
		

</head>
<body onload ="javascript:return FOCUS_FIRST();" onkeydown="javascript:return entertotab(event);" style="margin:0px 0px 0px 0px">
    <form id="form1" runat="server" style="margin:0px 0px 0px 0px">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
    <div id="div1" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
	  <table cellpadding="0" cellspacing="0"><tr><td>
	  <asp:ListBox ID="lstagency" Width="382px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox>
	  </td></tr></table></div>
	  
	    <div id="div2" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
	  <table cellpadding="0" cellspacing="0"><tr><td>
	  <asp:ListBox ID="lstexecutive" Width="382px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox>
	  </td></tr></table></div>
	  
	  
	  
	  
    
    <div>
   <table border="0" cellpadding="0" cellspacing="0" >
   
   
    <tr >
    <td colspan="0"><uc1:topbar id="Topbar1" runat="server" Text="Cash Recipt For Multiple Booking Id"></uc1:topbar></td>
    </tr>
    
   <tr>
   <td>
   <table align="center" >
    
    <tr >
    <td><asp:Label ID="lblagency12" runat="server" CssClass="TextField">Agency<font color="red">[F2]</font></asp:Label></td>
    <td><asp:TextBox  id="txtagency12" runat="server" CssClass="btext1"></asp:TextBox></td> 
    <td width="20px"></td>
    <td><asp:Label ID="lbladtype12" runat="server" CssClass="TextField">Ad Type</asp:Label></td>
       <td><asp:DropDownList  CssClass="dropdown" ID="drpadtype" runat="server"   >
       
                                                             
                                                        </asp:DropDownList>
       
       
       
       </td>
    </tr>
    
    
    
        <tr>
    <td><asp:Label ID="lblexecutive" runat="server" CssClass="TextField">Executive<font color="red">[F2]</font></asp:Label></td>
    <td><asp:TextBox  id="txtexecutive" runat="server" CssClass="btext1"
							></asp:TextBox></td><td>&nbsp;</td>
							
    <td><asp:Label ID="lblvalidfrom" runat="server" CssClass="TextField">Valid From<font color="red">*</font></asp:Label></td>
       <td><asp:TextBox ID="txtvalidityfrom" runat="server" CssClass="btext1" Enabled="true" MaxLength="10"   AutoPostBack="True"></asp:TextBox>
     
      <img src='Images/cal1.gif'  onclick='popUpCalendar(this,form1.txtvalidityfrom,"mm/dd/yyyy")' height="14" width="14" ></td>
    </tr>
    
    
    
    
    
     <tr>
     <td><asp:Label ID="lbladtype" runat="server" CssClass="TextField">Booking ID<font color="red"></font></asp:Label></td>
     <td><asp:TextBox  id="txtbookingid" runat="server" CssClass="btext1"
							></asp:TextBox></td><td width="40px">&nbsp;</td>
							<td><asp:Label ID="lblvalidto" runat="server" CssClass="TextField">Valid To<font color="red">*</font></asp:Label></td>
							<td><asp:textbox id="txttilldate" runat="server" CssClass="btext1" Enabled="true" MaxLength="10" AutoPostBack="True"></asp:textbox>
       
    <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txttilldate,"mm/dd/yyyy")' height="14" width="14" ></td>
							
							
							</tr>
    
    
    
    
    
     <tr>
     <td><asp:Label ID="lbladtype13" runat="server" CssClass="TextField">Adjust/Unadjusted</asp:Label></td>
     <td><asp:DropDownList  CssClass="dropdown" ID="drpadjusted" runat="server" 
               >
               <asp:ListItem Value="3" Text="All"></asp:ListItem>
               <asp:ListItem Value="1" Text="Adjusted"></asp:ListItem>
                                                            <asp:ListItem Value="2" Text="Unadjusted"></asp:ListItem>
         
                                                             
                                                        </asp:DropDownList>
       
       
       
         </td><td width="40px">&nbsp;</td>
							<td><asp:Label ID="lblbillamt" runat="server" CssClass="TextField">Bill Amount<font color="red"></font></asp:Label></td>
							<td><asp:TextBox  id="txtbillamt" runat="server" CssClass="btext1" Enabled="false"
							></asp:TextBox></td>
							
							
							</tr>
							<tr><td colspan="3" align="right" style="height: 24px"><asp:UpdatePanel ID="up60" runat="server"><ContentTemplate>
							<asp:button id="btnsubmit" 
                                    runat="server" CssClass="button1" Text="Submit" 
                                    onclick="btnsubmit_Click1" ></asp:Button></ContentTemplate></asp:UpdatePanel>
                                    </td><td>
             <asp:Button ID="btnclear" runat="server" CssClass="button1" Text="Clear" />
              </td>
     </tr>
     
    </table>
    
    <table cellpadding="0"  runat="server" cellspacing="0"  ><tr><td runat="server" align="center" id="g1" style="width:auto;margin:15px 40px;display:none;width:1000px"  >
    
     <div id="divgrid1"  runat="server" style="display:block; OVERFLOW: auto;width:100%; height:250px;" >
     <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
     <asp:DataGrid ID="DataGrid1" runat="server" CssClass="dtGrid"  AutoGenerateColumns="False"   OnItemDataBound="DataGrid1_ItemDataBound">
     <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
     <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></HeaderStyle>
     <Columns>
     <asp:TemplateColumn >
     </asp:TemplateColumn>
         <asp:TemplateColumn HeaderText="Sr. No."></asp:TemplateColumn>
         <asp:TemplateColumn HeaderText="Audit"></asp:TemplateColumn>
         
    <asp:BoundColumn DataField="APPROVAL_FLAG" HeaderText="Approval Flag" SortExpression="Edition_Alias">
    <ItemStyle HorizontalAlign="Center"></ItemStyle>
    <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
    Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
    </asp:BoundColumn>
          
     <asp:BoundColumn DataField="cio_booking_id" HeaderText="Booking Id" SortExpression="Edition_Alias">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
           <asp:BoundColumn DataField="RONO" HeaderText="RO No." SortExpression="RONO" >
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
           <asp:BoundColumn DataField="Receipt_no" HeaderText="Receipt No." SortExpression="Edition_Alias">
             <ItemStyle HorizontalAlign="Center"></ItemStyle>
              <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                 Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
                </asp:BoundColumn>
          
          <asp:BoundColumn DataField="Creation_datetime" HeaderText="Creation Date">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			
			
			   <asp:BoundColumn DataField="Bill Amount" HeaderText="Bill Amount">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			<asp:BoundColumn DataField="INSERT_DATE" HeaderText="Publish Date">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
          
          
          <asp:BoundColumn DataField="Client_code" HeaderText="Client Name" >
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			<asp:BoundColumn DataField="Agency_Remark" HeaderText="Agency Remark">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" Width="10%" />
			</asp:BoundColumn>
			
			<asp:BoundColumn DataField="Client_Remark" HeaderText="Client Remark" >
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" Width="10%" />
			</asp:BoundColumn>
			
			<asp:BoundColumn DataField="audit" HeaderText="Audited By" SortExpression="Date_Edition">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			<asp:BoundColumn DataField="RO" HeaderText="RO" SortExpression="RO" Visible="false">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
      <asp:BoundColumn SortExpression="Edition_Alias" DataField="ad_type_code" ReadOnly="True" Visible="False">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
      <asp:TemplateColumn >
     </asp:TemplateColumn>
     </Columns>
     </asp:DataGrid>     
     </ContentTemplate></asp:UpdatePanel></div>
     
     </td>
     <td valign="bottom">

     </tr>
     </table>
     
     <table align="center" width="40%" style="vertical-align:top;" >
     <tr valign="top">
     <td align="left" valign="top" ><asp:Label ID="lblpaymode123" Enabled="false" style="display:block;" runat="server" CssClass="TextField">Pay Mode</asp:Label></td>
     <td align="left"><asp:DropDownList ID="drppaymode" Enabled="false" style="display:block;" runat="server" CssClass="dropdown"> 

</asp:DropDownList></td>
  </tr>
</table>


<table align="center" width="60%" id="view" style="vertical-align:top;" >

<%--<td>  <asp:Label ID="lblcashrecieved0" style="display:none" runat="server" 
                 CssClass="TextField" ></asp:Label></td><td>
             <asp:TextBox ID="drpcashrecieved0" style="display:none"  onkeypress="return notchar2(event);" 
                 runat="server" CssClass="btext1">
                                         </asp:TextBox></td>--%>


     
     </tr>
     
     
                                     
                                
                                          <tr id="cashrecvd"  style="display:none">
                                            <td > 
                                       <asp:Label ID="Label3" runat="server" CssClass="TextField" Text="Cash Discount" ></asp:Label></td>
                                       <td id="Td2"  onkeypress="return notchar2(event);" runat="server"  ><asp:TextBox ID="txtcashdiscount" runat="server" CssClass="btext1">
                                         </asp:TextBox></td>
                                       <td id="Td1" runat="server" > 
                                       <asp:Label ID="lblcashrecieved" runat="server" CssClass="TextField" ></asp:Label></td>
                                       <td  runat="server"  ><asp:TextBox ID="drpcashrecieved" onkeypress="return notchar2(event);" runat="server" CssClass="btext1">
                                         </asp:TextBox></td>
                                         
                                 </tr>
                                         <tr>
                                            <td id="tdcarname" style="display:none" valign="top">
                                                <asp:Label ID="lbcardname"  runat="server" CssClass="TextField"></asp:Label></td>
                                            <td align="left" valign="top" id="tdtxtcarname" style="display:none">
                                                <asp:TextBox ID="txtcardname"  runat="server" CssClass="btext1"></asp:TextBox>
                                            </td>
                                            <td id="tdtype" style="display:none" valign="top">
                                                <asp:Label ID="lbtype"  runat="server" CssClass="TextField"></asp:Label></td>
                                            <td id="tddrptyp" style="display:none">
                                                <asp:DropDownList ID="drptype"  runat="server" CssClass="dropdown"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td id="tdexdat" style="display:none" valign="top">
                                                <asp:Label ID="lbexdate"  runat="server" CssClass="TextField"></asp:Label></td>
                                            <td align="left" valign="top" id="tdtxtexdat" style="display:none; ">
                                                <asp:DropDownList ID="drpmonth" runat="server" CssClass="drpsmall">
                                                <asp:ListItem Selected="True" Value="0">Month</asp:ListItem>
                                                <asp:ListItem  Value="1">Jan</asp:ListItem>
                                                <asp:ListItem  Value="2">Feb</asp:ListItem>
                                                <asp:ListItem  Value="3">Mar</asp:ListItem>
                                                <asp:ListItem  Value="4">Apr</asp:ListItem>
                                                <asp:ListItem  Value="5">May</asp:ListItem>
                                                <asp:ListItem  Value="6">Jun</asp:ListItem>
                                                <asp:ListItem  Value="7">Jul</asp:ListItem>
                                                <asp:ListItem  Value="8">Aug</asp:ListItem>
                                                <asp:ListItem  Value="9">Sep</asp:ListItem>
                                                <asp:ListItem  Value="10">Oct</asp:ListItem>
                                                <asp:ListItem  Value="11">Nov</asp:ListItem>
                                                <asp:ListItem  Value="12">Dec</asp:ListItem>
                                                </asp:DropDownList><asp:DropDownList ID="drpyear" runat="server" CssClass="drpsmall">
                                                <asp:ListItem Selected="true" Value="0">Year</asp:ListItem>
                                                <asp:ListItem  Value="2008">08</asp:ListItem>
                                                <asp:ListItem  Value="2009">09</asp:ListItem>
                                                <asp:ListItem  Value="2010">10</asp:ListItem>
                                                <asp:ListItem  Value="2011">11</asp:ListItem>
                                                <asp:ListItem  Value="2012">12</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td id="tdcardno" style="display:none" valign="top">
                                                <asp:Label ID="lbcardno"  runat="server" CssClass="TextField"></asp:Label></td>
                                            <td id="tdtxtcarno" style="display:none"  valign="top">
                                            <asp:TextBox ID="txtcardno"  runat="server" MaxLength="20" CssClass="btext1"></asp:TextBox>
                                            </td>
                                        </tr>
                                          <tr>
                                    <td id="tdchqno" runat="server" style="display:none">
                                        <asp:Label ID="lbchqno"  runat="server" CssClass="TextField"></asp:Label></td>
                                    <td id="tdtextchqno" runat="server" style="display:none">
                                        <asp:TextBox ID="ttextchqno" MaxLength="20"  runat="server" CssClass="btext1" ></asp:TextBox></td>
                                    <td id="tdchqamt" runat="server" style="display:none">
                                        <asp:Label ID="lbchqamt"  runat="server" CssClass="TextField"></asp:Label></td>
                                    <td align="left" valign="top" id="tdtextchqamt" style="display:none">                        
                                        <asp:TextBox ID="ttextchqamt"  runat="server" CssClass="btext1" ></asp:TextBox></td>
                                  </tr>
                                  <tr>
                                    <td id="tdchqdate" style="display:none">
                                        <asp:Label ID="lbchqdate"  runat="server" CssClass="TextField"></asp:Label></td>
                                    <td id="tdtextchqdate" style="display:none">
                                        <asp:TextBox ID="ttextchqdate"  runat="server" CssClass="btext1"></asp:TextBox></td>
                                    <td id="tdbankname" style="display:none"> 
                                        <asp:Label ID="lbbankname"  runat="server" CssClass="TextField"></asp:Label></td>
                                    <td id="tdtextbankname" style="display:none">                    
                                        <asp:TextBox ID="ttextbankname"  runat="server" CssClass="btext1"></asp:TextBox></td></tr>
                          
                                    <tr> <td style="text-align:left;"> <asp:Label ID="lbtobil1"  runat="server" 
                                            style=" height:13px; font-family: Trebuchet MS;font-size: 13px;color:black; display:none;" ></asp:Label> </td>
                                    <td colspan="2"> <asp:TextBox ID="ttexttobil1"  runat="server" CssClass="btext1" style="display:none;"></asp:TextBox> </td>
                                    </tr>
                                 
                                   <%-- <tr>  <td id="tdourbank" style="display:none">
                                        <asp:Label ID="lbourbank"  runat="server" Text="Our Bank" CssClass="TextField"></asp:Label></td>
                                       <td id="tdtextourbank" style="display:none">
                                         <asp:DropDownList ID="drpourbank"  runat="server" CssClass="dropdownforbook"></asp:DropDownList></td>
                                 </tr>--%>
                                        
                                      

     
     
     
     
     
     
     
     
     
     
     
     
     
     
     
     
     
     
     
     
     
     
     
     
     
     
     
          </table>
     
     <table align="center" width="30%" style="vertical-align:top;" >
     <tr ><td align="center">   <asp:UpdatePanel ID="UpdatePanel4" runat="server">
               <ContentTemplate>
         <asp:Button ID="btnmodify" enabled ="false" 
             runat="server" CssClass="button1" Width=100px  Text="Cash Received" onclick="btnmodify_Click" 
           />
           <asp:Button ID="btnreprint" enabled ="true" 
             runat="server" CssClass="button1" Width=100px  Text="Reprint Receipt" 
           />
           </ContentTemplate></asp:UpdatePanel></td></tr>
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
  <tr>
        <td align="right" colspan="2" >  
        
       
        
        
        
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
			<input id="hdnbutton" type="hidden" size="1" name="hdnbutton" runat="server"/>
			
			<input id="hdnexecutivetxt" type="hidden" size="1" name="hiddenbranch1" runat="server"/>
			<input id="hiddenserverip" type="hidden" size="1" name="hiddenbranch1" runat="server"/>
			<input id="hdnamt" type="hidden" size="1" name="hdnamt" runat="server"/>
			<input id="hiddenbk_audit" type="hidden" size="1" name="hiddenbranch" runat="server"/>
             <input id="hdnagencytxt" type="hidden" size="1" name="hdnagencytxt" runat="server"/>
                  <asp:UpdatePanel ID="UpdatePanel3" runat="server">
               <ContentTemplate><input id="hdnexecutive" type="hidden" size="1" name="hdnexecutive" runat="server"/>
                </ContentTemplate>
               </asp:UpdatePanel>
               
               <asp:UpdatePanel ID="UpdatePanel2" runat="server">
               <ContentTemplate> <input id="hdnlength" type="hidden" size="1" name="hdnexecutive" runat="server"/>
               </ContentTemplate>
               </asp:UpdatePanel>
          
   
    </form>
</body>
</html>

