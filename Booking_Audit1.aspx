<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Booking_Audit1.aspx.cs" Inherits="Booking_Audit1" EnableEventValidation="false" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Booking Audit </title>
    <link href="css/main.css" type="text/css" rel="stylesheet"/>
    <script type="text/javascript"language="javascript" src="javascript/popupcalender.js"></script>
		<%--<script language="javascript" src="javascript/permission.js"></script>
		<script language="javascript" src="javascript/datevalidation.js"></script>--%>
		<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
		<script  type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
		<script type="text/javascript"  language="javascript" src="javascript/booking_audit.js"></script>
		
		

    <style type="text/css">
        .style1
        {
            width: 21px;
        }
    </style>
		
		

</head>
<body onload ="javascript:return FOCUS_FIRST();"  onkeydown="javascript:return ttttt(event);">
    <form id="form1" method="post" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
       
         <div id="divimage" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
<table cellpadding="0" cellspacing="0"><tr><td>
  <asp:UpdateProgress DynamicLayout="false" ID="UpdateProgress1" runat="server">
          <ProgressTemplate>
           <img src="Images/loading6.gif" />
          </ProgressTemplate>
    </asp:UpdateProgress>
</td></tr></table></div>       
                        
                        
       
                  <div id="divagency" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
<table cellpadding="0" cellspacing="0"><tr><td>
<asp:ListBox ID="lstagency" Width="250px" Height="85px" runat="server" CssClass="btextlist" ></asp:ListBox>
</td></tr></table></div>       
                        
                        
                        
                        
                        
                        
		 
<div id="divclient" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
<table cellpadding="0" cellspacing="0"><tr><td>
<asp:ListBox ID="lstclient" Width="250px" Height="85px" runat="server" CssClass="btextlist" ></asp:ListBox>
</td></tr></table></div> 



<div id="divsection" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
<table cellpadding="0" cellspacing="0"><tr><td>
<asp:ListBox ID="lstsection" Width="250px" Height="85px" runat="server" CssClass="btextlist" ></asp:ListBox>
</td></tr></table></div> 

    <div>
    <table id="OuterTable" width="980" align="center" border="0" cellpadding="0" cellspacing="0">
    <tr >
    <td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Ad Booking Audit"></uc1:topbar></td>
    </tr>
    <tr>
        <td style="width: 932px">
        
     <table align="center" style="width: 90%"  >
     <tr>
     <td><asp:Label ID="lbladtype" runat="server" CssClass="TextField"> Ad Type<font color="red">*</font></asp:Label></td>
     <td><asp:DropDownList ID="drpadtype" runat="server" CssClass="dropdown"></asp:DropDownList></td>
     <td></td>
     <td><asp:Label ID="lblrevenu" runat="server" CssClass="TextField"> Publication Center<font color="red">*</font></asp:Label></td>
     <td><asp:DropDownList ID="drprevenu" runat="server" CssClass="dropdown"></asp:DropDownList></td>
     
     <td class="style1"></td>
     <td><asp:Label ID="lblbranch" runat="server" CssClass="TextField"> Branch<%--<font color="red">*</font>--%></asp:Label></td>
     <td><asp:DropDownList ID="drpbranch" runat="server" CssClass="dropdown"></asp:DropDownList></td>
     </tr>
     <tr>
      <td><asp:Label ID="Label2" runat="server" CssClass="TextField">Category<font color="red">*</font></asp:Label></td>
     <td><asp:DropDownList ID="drprate" runat="server" CssClass="dropdown"></asp:DropDownList></td>
   
       <td></td>
       <td ><asp:Label ID="lblvfrm" runat="server" CssClass="TextField"></asp:Label></td>
       <td ><asp:TextBox ID="txtvalidityfrom" runat="server" CssClass="btext1" Enabled="true" MaxLength="10" onfocus="javascript:return fetch(event);"  AutoPostBack="True"></asp:TextBox>
     
      <img src='Images/cal1.gif'  onclick='popUpCalendar(this,form1.txtvalidityfrom,"mm/dd/yyyy")' height="14" width="14" >
			</td>
		<td class="style1"></td>	
       <td><asp:Label ID="lblvalidtill" runat ="server" CssClass="TextField" Align="right"></asp:Label></td>
       <td> <asp:textbox id="txttilldate" runat="server" CssClass="btext1" Enabled="true" MaxLength="10" AutoPostBack="True"></asp:textbox>
       
    <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txttilldate,"mm/dd/yyyy")' height="14" width="14" >
	
      </td>
      
     </tr>
     
     
     <tr>
     

<td style="display:none;">
     <asp:Label ID="lbl_section"  CssClass="TextField" runat="server" style="visibility:hidden"></asp:Label>
     </td>
     <td style="display:none;">
     <asp:TextBox ID="txt_section" runat="server" CssClass="btext1" style="visibility:hidden"></asp:TextBox>
     </td>
<%--     <td class="style1"></td>	--%>
     <td >
					
            <asp:Label ID="lbagency" runat="server" CssClass="TextField" ></asp:Label></td>
	     	
	     	<td  >
	    
                    <asp:TextBox ID="txt_agency" runat="server" CssClass="btext1" ></asp:TextBox>
              </td>
                                                  
     <td class="style1"></td>
     
         <td align="left" >
    <asp:Label id="lbClient" runat="server" CssClass="TextField" ></asp:Label>
    </td>
    
    <td align="left">
    <asp:TextBox ID="txt_client" runat="server" CssClass="btext1"></asp:TextBox>

    </td>
    <td class="style1"></td>
       <td><asp:Label ID="Label1" runat="server" CssClass="TextField"> Audit Type</asp:Label></td>
     <td><asp:DropDownList ID="drpaudit" runat="server" CssClass="dropdown">
     <asp:ListItem Value="0" Text="Select"></asp:ListItem>
     <asp:ListItem Value="audit" Text="Audit"></asp:ListItem>
     <asp:ListItem Value="unaudit" Text="UnAudit"></asp:ListItem>
     <asp:ListItem Value="modified" Text="Modified"></asp:ListItem>
     </asp:DropDownList></td>
     </tr>
        <tr>
            <td >
                <asp:Label id="lbpackage" runat="server" CssClass="TextField" Text="Package"></asp:Label></td>
            <td style="HEIGHT: 25px" align="left">
                <asp:DropDownList id="drppackage" runat="server" CssClass="dropdown" ></asp:DropDownList>
            </td>
            <td class="style1"></td>
            <td><asp:Label ID="lblbooktyp" runat="server" CssClass="TextField"> Login Type</asp:Label></td>
            <td><asp:DropDownList ID="drpbooktyp" runat="server" CssClass="dropdown">
                <asp:ListItem Value="A" Text="All"></asp:ListItem>
                <asp:ListItem Value="D" Text="Company"></asp:ListItem>
                <asp:ListItem Value="Q" Text="Agency"></asp:ListItem>
                </asp:DropDownList></td><td></td>	
            <td  align="right" style="height: 24px">
            <asp:Label ID="lblum" runat="server" CssClass="TextField">Uom</asp:Label>
            </td>
            <td>
            <%--<asp:UpdatePanel ID="UpdatePanel22" runat="server"><ContentTemplate>--%>
                <asp:DropDownList ID="drpuom" runat="server" CssClass="dropdown">
                <asp:ListItem Value="0">--- Select Uom ---</asp:ListItem></asp:DropDownList><%--</ContentTemplate></asp:UpdatePanel>--%>
            </td>
       </tr>
      <tr>
             <td >
                <asp:Label id="Label4" runat="server" CssClass="TextField" Text="Date Based On"></asp:Label></td>
            <td style="HEIGHT: 25px" align="left">
                <asp:DropDownList id="Drpdatebasedon" runat="server" CssClass="dropdown" >
                    <asp:ListItem Value="B">Booking</asp:ListItem>
                    <asp:ListItem Value="P">Published</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style1"></td>
            	<td><asp:Label ID="lblBookingId" runat="server" CssClass="TextField">Booking Id</asp:Label></td>
       <td><asp:TextBox id="txtBookingId" runat="server" CssClass="btext1" ></asp:TextBox></td>
            <td></td><td></td>
            <td  style="height: 24px" colspan="2"><asp:UpdatePanel ID="up60" runat="server"><ContentTemplate><asp:button id="btnsubmit" runat="server" CssClass="button1" Text="Submit" OnClick="btnsubmit_Click"></asp:button>
                
         <%--   </td>
            <td>--%>
                <asp:Button ID="btnclear" runat="server" CssClass="button1" Text="Clear" OnClick="btnclear_Click" />
                <asp:Button ID="btnExit" runat="server" CssClass="button1" Text="Exit" /></ContentTemplate></asp:UpdatePanel>
            </td>
       </tr>
      </table>
    
   <table cellpadding="0" cellspacing="0" style="width:auto;margin:15px 40px;" ><tr><td align="center" style="width:1000px">
    
     <div id="divgrid1"  runat="server" style="display:block; OVERFLOW: auto;width:100%; height:250px;">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
     <asp:DataGrid ID="DataGrid1" runat="server" CssClass="dtGrid"  AutoGenerateColumns="False" OnItemDataBound="DataGrid1_ItemDataBound" OnSelectedIndexChanged="DataGrid1_SelectedIndexChanged">
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
			
			<asp:BoundColumn DataField="FILENAME" HeaderText="Mat_status" SortExpression="Mat_st">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
      <asp:BoundColumn SortExpression="Edition_Alias" DataField="ad_type_code" ReadOnly="True" Visible="False">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
     <asp:BoundColumn DataField="ATTACHMENT" HeaderText="Attachment" SortExpression="Edition_Alias">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
           <asp:BoundColumn DataField="ATTACHMENT1" HeaderText="Attachment" SortExpression="Edition_Alias">
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
     <asp:Button ID="btnbookingaudit" runat="server" CssClass="button1" Text="Audit Selected" OnClick="btnaudit_Click3"  />
     </ContentTemplate></asp:UpdatePanel></td>
     </tr>
     </table>
     <table align="center"><tr><td align="center">
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
    <td><asp:Label ID="lblcaption" runat="server" CssClass="TextField"></asp:Label></td>
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
        <asp:TextBox ID="txtuom"  CssClass="btext1_BOOKADI"  runat="server"></asp:TextBox></td>
    <td></td>
    
      
   <td align="left"><asp:Label ID="lblcgst" runat="server" CssClass="TextField"  ></asp:Label></td>
    <td><asp:TextBox ID="txtcgst"  CssClass="btext1_BOOKADI"  runat="server"></asp:TextBox></td>
    <td align="left" ></td>   
    
    <td align="right" colspan="2" >  
        <asp:Button ID="btnrefresh" Enabled="false" runat="server" CssClass="button1" Text="Refresh" />   
        <asp:UpdatePanel ID="UpdatePanel5" runat="server"><ContentTemplate>
        <asp:Button ID="btnmodify" runat="server" CssClass="button1" Text="Show Detail" 
         />
        <asp:button id="btnaudit" runat="server" CssClass="button1" Text="Audit" OnClick="btnaudit_Click1" />
        <asp:button id="btnpreview" runat="server" CssClass="button1" Text="Preview"/>
        <asp:Button ID="btnunaudit" runat="server" CssClass="button1" Text="UnAudit" OnClick="btnunaudit_Click" />
        </ContentTemplate></asp:UpdatePanel>
    </td>
</tr>
            <tr><td align="left"><asp:Label ID="lblsgst" runat="server" CssClass="TextField"  ></asp:Label></td>
    <td><asp:TextBox ID="txtsgst"  CssClass="btext1_BOOKADI"  runat="server"></asp:TextBox></td><td></td>
    <td align="left"><asp:Label ID="lbligst" runat="server" CssClass="TextField"  ></asp:Label></td>
    <td><asp:TextBox ID="txtigst"  CssClass="btext1_BOOKADI"  runat="server"></asp:TextBox></td>
    </tr>
<tr>

     <td align="left"><asp:Label ID="lbalert" runat="server" CssClass="TextField"></asp:Label></td>
     <td colspan="4" >
        <asp:TextBox ID="txtallert" TextMode="multiLine" CssClass="btext1_BOOKADI" Width="450px" Height="50px" runat="server"></asp:TextBox></td>
     
</tr>
<tr>
     <td align="left"><asp:Label ID="lblremarks" runat="server" CssClass="TextField"></asp:Label></td>
     <td colspan="4" >
        <asp:TextBox ID="txtremarks" TextMode="multiLine" CssClass="btext1_BOOKADI" Width="450px" Height="50px" runat="server"></asp:TextBox></td>
     <td align="left" colspan="3">
        <asp:Button ID="btnsave1" Enabled="false" runat="server" Width="100" CssClass="button1" Text="Save Comments" /></td>
    
</tr>   

<tr>
     <td align="left"><asp:Label ID="Label3" runat="server" CssClass="TextField">comment  other languuage</asp:Label></td>
     <td colspan="4" ><asp:UpdatePanel ID="UpdatePanel49" runat="server" ><ContentTemplate>
        <asp:TextBox ID="txt_otherlanguage" TextMode="multiLine" CssClass="btext1_BOOKADI" Width="450px" Height="50px" runat="server" Font-Names="4CAadita" Font-Size="16px"  ></asp:TextBox></ContentTemplate></asp:UpdatePanel> </td>
     <td align="left" colspan="3">

    
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
					<input id="hiddenserverip" type="hidden" size="1" name="hiddenbranch1" runat="server"/>
			<input id="hdnexecutivetxt" type="hidden" size="1" name="hiddenbranch1" runat="server"/>
			
			<input id="hiddenbk_audit" type="hidden" size="1" name="hiddenbranch" runat="server"/>
				<input id="hdn_package" type="hidden" size="1"  runat="server"/>
				<input id="hdn_uom" type="hidden"  runat="server"/>
				<input id="hidden_agency" type="hidden" size="1"  runat="server"/>
			
				<input id="hidden_client" type="hidden" size="1"  runat="server"/>
				<input id="hidden_section" type="hidden" size="1"  runat="server"/>
			<input id="hidattach1" type="hidden" size="1"  runat="server"/>
				<input id="hidden1" value="0" type="hidden" name="hiddenrefresh" runat="server" />
			<input id="hidattach11" type="hidden" size="1"  runat="server"/>

			<input id="hdnbranch" type="hidden" size="1"  runat="server"/>
			<input id="hdncenter" type="hidden" size="1"  runat="server"/>
            	<input id="hiddenagency" type="hidden" size="1"  runat="server"/>
			
			
			
    </form>
</body>
</html>
