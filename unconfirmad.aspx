<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="unconfirmad.aspx.cs" Inherits="unconfirmad" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Records of Unconfirm Ads</title>
    <link href="css/main.css" type="text/css" rel="stylesheet"/>
    <script type="text/javascript"language="javascript" src="javascript/popupcalender.js"></script>
		<%--<script language="javascript" src="javascript/permission.js"></script>
		<script language="javascript" src="javascript/datevalidation.js"></script>--%>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script  type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/unconfirmad.js"></script>
</head>
<body onkeydown="javascript:return tabvalue1(event);">
    <form id="form1" method="post" runat="server">
    <div id="div1" style="position: absolute; top: 0px; left: 0px; border: none; display: none;
            z-index: 1; " >
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:ListBox ID="lstagency" Width="350px" Height="80px" runat="server" CssClass="btextlist">
                        </asp:ListBox></td>
                </tr>
            </table>
        </div>
    <div>
    <table id="OuterTable" width="980" align="center" border="0" cellpadding="0" cellspacing="0">
    <tr >
    <td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Records of Unconfirm Ads"></uc1:topbar></td>
    </tr>
    <tr>
        <td style="width: 966px">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
     <table align="center">
     <tr>
    <%-- <td><asp:Label ID="lbladtype" runat="server" CssClass="TextField"> Ad Type<font color="red">*</font></asp:Label></td>
     <td><asp:DropDownList ID="drpadtype" runat="server" CssClass="dropdown"></asp:DropDownList></td>--%>
   
     <td><asp:Label ID="lblrevenu" runat="server" CssClass="TextField">Agency<font color="red">[F2]</font></asp:Label></td>
     <td><asp:TextBox ID="drprevenu" runat="server" CssClass="btext1"></asp:TextBox></td>
     <td></td>
     <td><asp:Label ID="Label1" runat="server" CssClass="TextField">Booking Status</asp:Label></td>
     <td><asp:DropDownList ID="drpconfirm" runat="server" CssClass="dropdown">
     <asp:ListItem Value="2" Text="UnConfirm"></asp:ListItem>
     <asp:ListItem Value="1" Text="Confirm"></asp:ListItem>
     </asp:DropDownList></td>
     <td><asp:Label ID="Label2" runat="server" CssClass="TextField"></asp:Label></td>
     <td><asp:DropDownList ID="drpadtype" runat="server" CssClass="dropdown">
     </asp:DropDownList></td>
     <%--<td></td>
     <td><asp:Label ID="lblbranch" runat="server" CssClass="TextField"> Branch</asp:Label></td>
     <td><asp:DropDownList ID="drpbranch" runat="server" CssClass="dropdown"></asp:DropDownList></td>--%>
     </tr>
     <tr>
       
       <td ><asp:Label ID="lblvfrm" runat="server" CssClass="TextField"></asp:Label></td>
       <td ><asp:UpdatePanel ID="up61" runat="server"><ContentTemplate><asp:TextBox ID="txtvalidityfrom" runat="server" CssClass="btext1" Enabled="true" MaxLength="10" onfocus="javascript:return fetch(event);"  AutoPostBack="True"></asp:TextBox>
     
      <img src='Images/cal1.gif'  onclick='popUpCalendar(this,form1.txtvalidityfrom,"mm/dd/yyyy")' height="14" width="14" >
			</ContentTemplate></asp:UpdatePanel></td>
		<td></td>	
       <td><asp:Label ID="lblvalidtill" runat ="server" CssClass="TextField" Align="right"></asp:Label></td>
       <td><asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate> <asp:textbox id="txttilldate" runat="server" CssClass="btext1" Enabled="true" MaxLength="10" AutoPostBack="True"></asp:textbox>
       
    <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txttilldate,"mm/dd/yyyy")' height="14" width="14" >
		</ContentTemplate></asp:UpdatePanel>
      </td>
    <%--  //////////////////add by anuja printing center for udyavani--%>
       <td><asp:Label ID="lblprint" runat="server" CssClass="TextField"></asp:Label></td>
     <td><asp:DropDownList ID="drprinting" runat="server" CssClass="dropdown">
     </asp:DropDownList></td>
  <%--   ///////////////////////////////////////end--%>
     </tr>
       <tr>
     
     <td></td>
          <td></td>
              <td colspan="4" align="right" style="height: 24px"><asp:UpdatePanel ID="up60" runat="server"><ContentTemplate><asp:button id="btnsubmit" runat="server" CssClass="button1" Text="Submit" OnClick="btnsubmit_Click"></asp:button>
             <asp:Button ID="btnclear" runat="server" CssClass="button1" Text="Clear" OnClick="btnclear_Click" /></ContentTemplate></asp:UpdatePanel>
              </td>
              </tr>
      </table>
   <table cellpadding="0" cellspacing="0" width="100%"><tr><td align="center">
     <div id="divgrid1"  runat="server" style="display:none; OVERFLOW: auto; WIDTH: 700px;">
     <table id="Table3" align="center">
     <tr>       
     <td align="center">
     <div style="overflow:auto;height:162px" >
     <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
     <asp:DataGrid ID="DataGrid1" runat="server" CssClass="dtGrid" Width="570px" AutoGenerateColumns="False" OnItemDataBound="DataGrid1_ItemDataBound" OnSelectedIndexChanged="DataGrid1_SelectedIndexChanged">
     <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
     <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></HeaderStyle>
     <Columns>
     <asp:TemplateColumn >
     </asp:TemplateColumn>
         <asp:BoundColumn DataField="SAPID" HeaderText="SAP ID" Visible="False"></asp:BoundColumn>
     <asp:BoundColumn DataField="cio_booking_id" HeaderText="Booking Id" >
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
          <asp:BoundColumn DataField="Client_code" HeaderText="Client Id" SortExpression="Date_Edition">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			<asp:BoundColumn DataField="audit" HeaderText="Audited By" SortExpression="Date_Edition" Visible="False">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
      <asp:BoundColumn SortExpression="Edition_Alias" DataField="ad_type_code" ReadOnly="True" Visible="False">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
          <asp:BoundColumn DataField="RO_No" HeaderText="RO No" SortExpression="Date_Edition">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			<asp:BoundColumn DataField="Dockit_no" HeaderText="Dockit No" SortExpression="Date_Edition">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			<asp:BoundColumn DataField="Receipt_date" HeaderText="Receipt_Date" SortExpression="Date_Edition">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			<asp:BoundColumn DataField="Agency_Name" HeaderText="Agency_Name" SortExpression="Date_Edition">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
     </Columns>
     </asp:DataGrid>     
     </ContentTemplate></asp:UpdatePanel></div>
     
     </td>
     <td valign="bottom">
     <asp:UpdatePanel ID="UpdatePanel44" runat="server"><ContentTemplate>
     <asp:Button ID="btnbookingaudit" runat="server" CssClass="button1" Text="Confirm RO" OnClick="btnaudit_Click3"  />
     </ContentTemplate></asp:UpdatePanel></td>
     </tr>
     </table>
    </div>
     </td></tr></table>
     <table align="center"><tr><td align="center">
     <div id="maintbl" runat="server">
        <table>    
        <tr>
<td align="left"><asp:Label ID="lblagency" runat="server" CssClass="TextField" ></asp:Label></td>
        <td> <asp:UpdatePanel ID="UpdatePanel6" runat="server"><ContentTemplate><asp:TextBox ID="txtagency" CssClass="btext1" runat="server" TextMode="MultiLine"></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
<td align="left"><asp:Label ID="lbluom" runat="server" CssClass="TextField"  ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel25" runat="server"><ContentTemplate><asp:TextBox ID="txtuom" CssClass="btext1" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
        <td align="left"><asp:Label ID="lblagreedrate" runat="server" CssClass="TextField"></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel38" runat="server"><ContentTemplate><asp:TextBox ID="txtagreedrate" CssClass="btext1numeric" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
       
        
</tr>

<tr>
<td align="left"><asp:Label ID="lblclient" runat="server" CssClass="TextField" ></asp:Label></td>
        <td> <asp:UpdatePanel ID="UpdatePanel4" runat="server"><ContentTemplate><asp:TextBox ID="txtclient" CssClass="btext1" runat="server" TextMode="multiLine"></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
        
<td style="width:40px"></td>
 <td align="left"><asp:Label ID="lblpackage" runat="server" CssClass="TextField"></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel31" runat="server"><ContentTemplate><asp:TextBox ID="txtpackage" CssClass="btext1" runat="server" TextMode="MultiLine" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:35px"></td>
        <td align="left"><asp:Label ID="lblagreedamount" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel9" runat="server"><ContentTemplate><asp:TextBox ID="txtagreedamount" CssClass="btext1numeric" runat="server"></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>           
</tr>

<tr>
<td align="left"><asp:Label ID="lblpaymode" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel11" runat="server"><ContentTemplate><asp:TextBox ID="txtpaymode" CssClass="btext1" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:35px"></td>        
<td align="left"><asp:Label ID="lblpublichdate" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel32" runat="server"><ContentTemplate><asp:TextBox ID="txtpublishdate" CssClass="btext1" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:35px"></td>
<td align="left"><asp:Label ID="lbldiscount" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel40" runat="server"><ContentTemplate><asp:TextBox ID="txtdiscount" CssClass="btext1numeric" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
             
</tr>

<tr>
<td align="left"><asp:Label ID="lblrono" runat="server" CssClass="TextField" ></asp:Label></td>
        <td ><asp:UpdatePanel ID="UpdatePanel13" runat="server"><ContentTemplate><asp:TextBox ID="txtrono" CssClass="btext1numeric" runat="server"></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
        
<td style="width:40px"></td>
        <td align="left"><asp:Label ID="lblnoofinsertion" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel33" runat="server"><ContentTemplate><asp:TextBox ID="txtnoofinsertion" CssClass="btext1numeric" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
         <td align="left"><asp:Label ID="lblpositionpremium" runat="server" CssClass="TextField" ></asp:Label></td>
        <td ><asp:UpdatePanel ID="UpdatePanel27" runat="server"><ContentTemplate><asp:TextBox ID="txtpositionpremium" CssClass="btext1" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
                
</tr>

<tr>
<td align="left"><asp:Label ID="lblrostatus" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel15" runat="server"><ContentTemplate>
        <asp:TextBox ID="txtrostatus"  CssClass="btext1" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
       
<td style="width:40px"></td>
        <td align="left"><asp:Label ID="lblpaid" runat="server" CssClass="TextField"></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel36" runat="server"><ContentTemplate><asp:TextBox ID="txtpaid" CssClass="btext1numeric" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
        
<td style="width:40px"></td>
        <td align="left"><asp:Label ID="lblspecialdiscount" runat="server" CssClass="TextField"></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel39" runat="server"><ContentTemplate><asp:TextBox ID="txtspecialdiscount" CssClass="btext1numeric" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

</tr>

<tr>
<td align="left"><asp:Label ID="lblexecutivename" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel18" runat="server"><ContentTemplate><asp:TextBox ID="txtexecutivename" CssClass="btext1" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
        
<td style="width:40px"></td>
<td align="left"><asp:Label ID="lblcontractname" runat="server" CssClass="TextField"></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel34" runat="server"><ContentTemplate><asp:TextBox ID="txtcontractname" CssClass="btext1" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
<td align="left"><asp:Label ID="lblspacediscount" runat="server" CssClass="TextField"></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel42" runat="server"><ContentTemplate><asp:TextBox ID="txtspacediscount" CssClass="btext1numeric" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

</tr>

<tr>
<td align="left"><asp:Label ID="lbloutstanding" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel20" runat="server"><ContentTemplate><asp:TextBox ID="txtoutstanding" CssClass="btext1numeric" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>        
<td align="left"><asp:Label ID="lblheight" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel29" runat="server"><ContentTemplate><font Class="TextField">&nbsp;H&nbsp;</font><asp:TextBox ID="txtheight" CssClass="btext1numeric" style="width:50px" runat="server" ></asp:TextBox><font Class="TextField">&nbsp;W&nbsp;</font><asp:TextBox ID="txtwidth" style="width:50px;" CssClass="btext1numeric" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
        <td align="left"><asp:Label ID="lblspecialcharge" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel17" runat="server"><ContentTemplate><asp:TextBox ID="txtspecialcharge" CssClass="btext1numeric" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
        
</tr>
<tr>
<td align="left"><asp:Label ID="lblretainername" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel10" runat="server"><ContentTemplate><asp:TextBox ID="txtretainername" CssClass="btext1" runat="server" TextMode="MultiLine"></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
<td align="left"><asp:Label ID="lbllines" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel30" runat="server"><ContentTemplate><asp:TextBox ID="txtlines" CssClass="btext1numeric" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

 <td style="width:40px"></td>
        <td align="left"><asp:Label ID="lbladdagecomm" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel12" runat="server"><ContentTemplate><asp:TextBox ID="txtaddagecomm" CssClass="btext1numeric" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>       

</tr>

<tr>
<td align="left"><asp:Label ID="lblbookingtype" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel19" runat="server"><ContentTemplate><asp:TextBox ID="txtbookingtype" CssClass="btext1" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
        <td align="left"><asp:Label ID="lblpageposition" runat="server" CssClass="TextField"  ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel26" runat="server"><ContentTemplate><asp:TextBox ID="txtpageposition" CssClass="btext1" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
         <td align="left"><asp:Label ID="lblgrossamt" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel3" runat="server"><ContentTemplate><asp:TextBox ID="txtgrossamt" CssClass="btext1numeric" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
                
</tr>

<tr>
<td align="left"><asp:Label ID="lblcolourtype" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel28" runat="server"><ContentTemplate><asp:TextBox ID="txtcolourtype" CssClass="btext1" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
         <td align="left"><asp:Label ID="lblpositionpre" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel7" runat="server"><ContentTemplate><asp:TextBox ID="txtpositionpre" CssClass="btext1" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
        
<td style="width:40px"></td>
        <td align="left"><asp:Label ID="lblretainercommission" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel24" runat="server"><ContentTemplate><asp:TextBox ID="txtretainercommission" CssClass="btext1numeric" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

</tr>

<tr>
<td align="left"><asp:Label ID="lbladcategory" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel21" runat="server"><ContentTemplate><asp:TextBox ID="txtadcategory" CssClass="btext1" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
        
<td style="width:40px"></td>
        <td align="left"><asp:Label ID="lblarea" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel8" runat="server"><ContentTemplate><asp:TextBox ID="txtarea" CssClass="btext1" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
<td align="left"><asp:Label ID="lblagtradediscount" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel23" runat="server"><ContentTemplate><asp:TextBox ID="txtagtradediscount" Enabled="false" CssClass="btext1numeric" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
        
</tr>

<tr>
<td align="left"><asp:Label ID="lbladsubcat1" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel235" runat="server"><ContentTemplate><asp:TextBox ID="txtadsubcat1" CssClass="btext1" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
        <td align="left"><asp:Label ID="lblschemetype" runat="server" CssClass="TextField"></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel35" runat="server"><ContentTemplate><asp:TextBox ID="txtschemetype" CssClass="btext1" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
        
<td style="width:40px"></td>
        <td align="left"><asp:Label ID="lbdiscountinrate" runat="server" Text="Agency Discount in Rate" CssClass="TextField"></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel43" runat="server"><ContentTemplate><asp:TextBox ID="txtagencydiscinarte" CssClass="btext1numeric" Enabled="false" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

</tr>

<tr>
<td align="left"><asp:Label ID="lbladsubcat2" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel234" runat="server"><ContentTemplate><asp:TextBox ID="txtadsubcat2" CssClass="btext1" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
<td align="left"><asp:Label ID="lblratecode" CssClass="TextField" runat="server"></asp:Label></td>
        <td>
         <asp:UpdatePanel ID="UpdatePanel14" runat="server"><ContentTemplate>
        <asp:TextBox ID="txtratecode" CssClass="btext1" runat="server"></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
<td align="left"><asp:Label ID="lblbillamount" runat="server" CssClass="TextField"></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel41" runat="server"><ContentTemplate><asp:TextBox ID="txtbillamount" CssClass="btext1numeric" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
</tr>

<tr>
<td align="left"><asp:Label ID="lbladsubcat3" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel236" runat="server"><ContentTemplate><asp:TextBox ID="txtadsubcat3" CssClass="btext1" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
        <td align="left"><asp:Label ID="lblcardrate" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel16" runat="server"><ContentTemplate><asp:TextBox ID="txtcardrate" CssClass="btext1numeric"  runat="server"></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
</tr>

<tr>
<td align="left"><asp:Label ID="lbladsubcat4" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel22" runat="server"><ContentTemplate><asp:TextBox ID="txtadsubcat4" CssClass="btext1" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
<td align="left"><asp:Label ID="lblcardamount" runat="server" CssClass="TextField"></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel37" runat="server"><ContentTemplate><asp:TextBox ID="txtcardamount" CssClass="btext1numeric" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td align="left" style="display:none">
    <asp:Button ID="btnrefresh" Enabled="false" runat="server" CssClass="button1" Text="Refresh" /> 
    </td>   
    <td align="right" colspan="2" style="display:none" >    
    <asp:UpdatePanel ID="UpdatePanel5" runat="server"><ContentTemplate><asp:Button ID="btnmodify"  runat="server" CssClass="button1" Text="Show Detail" OnClick="btnmodify_Click" /><asp:button id="btnaudit" runat="server" CssClass="button1" Text="Audit"  /><asp:button id="btnpreview" runat="server" CssClass="button1" Text="Preview"/><asp:Button ID="btnunaudit" runat="server" CssClass="button1" Text="UnAudit"  /></ContentTemplate></asp:UpdatePanel>
    </td>

        
</tr>
<tr>
      <td align="left" style="display:none"><asp:Label ID="lblremarks" runat="server" CssClass="TextField"></asp:Label></td>
     <td colspan="4" style="display:none"><asp:UpdatePanel ID="UpdatePanel45" runat="server"><ContentTemplate><asp:TextBox ID="txtremarks" TextMode="multiLine" CssClass="btext1" Width="450px" Height="50px" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel> </td>
<td align="left" colspan="2" style="display:none">
    <asp:Button ID="btnsave1" Enabled="false" runat="server" Width="100" CssClass="button1" Text="Save Comments" /> 
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
			<input id="hiddensh" type="hidden" size="1" name="hiddensh" runat="server"/>
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
    </form>
</body>
</html>
