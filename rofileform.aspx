<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeFile="rofileform.aspx.cs" Inherits="rofileform" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>R.O.File Form</title>
    <link href="css/main.css" type="text/css" rel="stylesheet"/>
    <script type="text/javascript"language="javascript" src="javascript/popupcalender.js"></script>
	<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
	<script  type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>
	<script type="text/javascript"  language="javascript" src="javascript/bookaudit.js"></script>
	<script type="text/javascript"  language="javascript" src="javascript/rofileform.js"></script>
    <script language="javascript"  type="text/javascript" src="javascript/datevalidation.js"></script>
</head>
<body onload="javascript:return FOCUS_FIRST1();"  onkeydown="javascript:return tabvalue1(event);">
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
        <div id="divclient" style="position: absolute; top: 0px; left: 0px; border: none;
            display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        
                                <asp:ListBox ID="lstclient" Width="350px" Height="65px" runat="server" CssClass="btextlist">
                                </asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
        <div id="divexec" style="position: absolute; top: 0px; left: 0px; border: none; display: none;
            z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        
                                <asp:ListBox ID="lstexec" Width="254px" Height="65px" runat="server" CssClass="btextlist">
                                </asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
         <div id="divretainer" style="position: absolute; top: 0px; left: 0px; border: none;
            display: none; z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        
                                <asp:ListBox ID="lstretainer" Width="254px" Height="65px" runat="server" CssClass="btextlist">
                                </asp:ListBox>
                    </td>
                </tr>
            </table>
        </div>
    <div>
    <table id="OuterTable" width="980" align="center" border="0" cellpadding="0" cellspacing="0">
    <tr >
    <td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="R.O.File Form"></uc1:topbar></td>
    </tr>
    <tr>
        <td style="width: 966px">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
     <table align="center">
         <tr>                                                     
                <td><asp:Label id="lbPublicationCenter" runat="server" CssClass="TextField">PublicationCenter</asp:Label></td>
                <td style="HEIGHT: 25px" align="left"><asp:DropDownList id="dppubcent" runat="server" CssClass="dropdown"></asp:DropDownList></td>                                                

                <td><asp:Label id="lbldist" runat="server" CssClass="TextField">District</asp:Label></td>
                <td style="HEIGHT: 25px" align="left"><asp:DropDownList id="drpdist" runat="server" CssClass="dropdown"></asp:DropDownList></td>                                             


                <td align="left"><asp:Label id="Label1" runat="server" CssClass="TextField">Agency</asp:Label></td>
                <td ><asp:TextBox id="txtagency1" runat="server" CssClass="btext1" ></asp:TextBox></td>                                         

                <td align="left"><asp:Label id="Label7" runat="server" CssClass="TextField">Executive</asp:Label></td>
                <td ><asp:TextBox id="txtexecname" runat="server" CssClass="btext1" ></asp:TextBox></td>                                        
                                                            
          </tr>
     
     <tr>
     
                 <td align="left" ><asp:Label id="Label2" runat="server" CssClass="TextField" >Branch</asp:Label></td>
                 <td align="left"><asp:DropDownList CssClass="dropdown" id="drpbranch" runat="server" ></asp:DropDownList></td> 
                 <td align="left" ><asp:Label id="Label3" runat="server" CssClass="TextField" >Taluka</asp:Label></td>
                 <td align="left"><asp:DropDownList CssClass="dropdown" id="DropDownList3" runat="server" ></asp:DropDownList></td>
                 <td align="left"><asp:Label id="Label4" runat="server" CssClass="TextField">Retainer</asp:Label></td>
	             <td ><asp:TextBox id="dpretainer" runat="server" CssClass="btext1" ></asp:TextBox></td>
	             <td align="left" ><asp:Label id="lbClient" runat="server" CssClass="TextField">Client</asp:Label></td>
	             <td align="left"><asp:TextBox CssClass="btext1" id="txtclient1" runat="server" ></asp:TextBox></td>
     
     </tr>
     <tr>
    
                <td ><asp:Label ID="lblvfrm" runat="server" CssClass="TextField"></asp:Label></td>
                <td ><asp:TextBox ID="txtvalidityfrom" runat="server" CssClass="btext1" Enabled="true" MaxLength="10"    AutoPostBack="True"></asp:TextBox>
                <img src='Images/cal1.gif'  onclick='popUpCalendar(this,form1.txtvalidityfrom,"mm/dd/yyyy")' height="14" width="14" /></td>
                <td><asp:Label ID="lblvalidtill" runat ="server" CssClass="TextField" Align="right"></asp:Label></td>
                <td> <asp:textbox id="txttilldate" runat="server" CssClass="btext1" Enabled="true" MaxLength="10" AutoPostBack="True"></asp:textbox>
                <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txttilldate,"mm/dd/yyyy")' height="14" width="14" ></td>
                <td align="left" ><asp:Label id="Label5" runat="server" CssClass="TextField" >Pay Mode</asp:Label></td>
                <td align="left"><asp:DropDownList CssClass="dropdown" id="DropDownList4" runat="server" ></asp:DropDownList></td>
                <td align="left" ><asp:Label id="lblrodocstatus" runat="server" CssClass="TextField">RO Doc. Status</asp:Label></td>
	             <td align="left"><asp:DropDownList CssClass="dropdown" id="drprodocstatus" runat="server" >
                <asp:ListItem Value="A">All</asp:ListItem>
	             <asp:ListItem Value="0">Blank Ro</asp:ListItem>
	             <asp:ListItem Value="x">Xerox</asp:ListItem>
	             <asp:ListItem Value="o">Original</asp:ListItem>
	             <asp:ListItem Value="f">Fax</asp:ListItem>
	             </asp:DropDownList></td>
     </tr>
  
          <tr>
         	
														
			<td align="left"><asp:Label id="Label6" runat="server" CssClass="TextField">Ro no</asp:Label></td>
	        <td ><asp:TextBox id="tbrono" runat="server" CssClass="btext1" ></asp:TextBox></td>
            <td align="left" ><asp:Label id="Label8" runat="server" CssClass="TextField">Booking id</asp:Label></td>
            <td align="left"><asp:TextBox CssClass="btext1" id="tbbookingid" runat="server" ></asp:TextBox></td>												
														
														
															     
														
														
														
														
              <td colspan="2" align="right" style="height: 24px">
              
              <asp:UpdatePanel ID="update101" runat ="server" >
              <ContentTemplate >
             
               </ContentTemplate>
              </asp:UpdatePanel>

              </td>
              <td align="right" colspan="1">
              
              <asp:UpdatePanel ID="UpdatePanel16" runat ="server" >
              <ContentTemplate >
              <asp:button id="btnsubmit" runat="server" CssClass="button1" Text="SHOW DETAILS" OnClick="btnsubmit_Click"  ></asp:button><%--OnClick="btnsubmit_Click"--%>
              </ContentTemplate>
          </asp:UpdatePanel>
              
              </td>
              <td>
                   <asp:button id="btnExit" runat="server" CssClass="button1" Text="Exit"  ></asp:button>
              </td>
          </tr>
     </table>
     
     <tr>
     <td>
    
     

   <table cellpadding="0" cellspacing="0"  width="100%">
       <tr valign="top" >
           <td align="center">
               <table id="Table3"  align="center">
                     <tr>
                         <td align="center">
                         <div style="OVERFLOW: auto; WIDTH: 950px; HEIGHT: 250px">
                             <asp:UpdatePanel ID="updategrid" runat ="server" >
                                 <ContentTemplate >
                                         <asp:DataGrid ID="DataGrid1" runat="server"  CssClass="dtGrid"  Width="950px"  AutoGenerateColumns="False" OnItemDataBound="DataGrid1_ItemDataBound"> <%--OnItemDataBound="DataGrid1_ItemDataBound"  >--%><%--OnItemDataBound="DataGrid1_ItemDataBound"--%>
                                                 <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
                                                 <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></HeaderStyle>
                                                 <Columns>
                                                         <asp:BoundColumn  HeaderText="S.No" >
			                                             <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                         <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			                                             </asp:BoundColumn>
			                                             <asp:BoundColumn DataField="cio_booking_id" HeaderText="Booking Id" SortExpression="Edition_Alias">
                                                         <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                         <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
                                                         </asp:BoundColumn>
			                                            <asp:BoundColumn DataField="Agency R.o.No"  HeaderText="Agency R.o.No" >
			                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			                                            </asp:BoundColumn>
			                                            <asp:BoundColumn DataField="Agency Name"  HeaderText="Agency Name" >
			                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			                                            </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="Client Name"  HeaderText="Client Name" >
			                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			                                            </asp:BoundColumn>
			                                            <asp:BoundColumn DataField="Ad_type_code"  HeaderText="Ad_type_code" Visible="false" >
			                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			                                            </asp:BoundColumn>
			                                            <asp:BoundColumn DataField="RODOCSTATUS" HeaderText="Tick Vlue">
			                                            <ItemStyle ></ItemStyle>
                                                        <HeaderStyle/>
			                                            </asp:BoundColumn>
			                                            <asp:BoundColumn HeaderText="Update">
			                                            <ItemStyle></ItemStyle>
                                                        <HeaderStyle/>
			                                            </asp:BoundColumn>
                                                 </Columns>
                                         </asp:DataGrid>
                                 </ContentTemplate>
                             </asp:UpdatePanel>
                             </div>
                         </td>
                     </tr>
                 </table>
           </td>
       </tr>
   </table>
      </td>
     </tr>
     <table align="center"><tr><td align="center">
     <div id="maintbl" runat="server">
        <table>
        <tr>
        <%--<td><asp:CheckBox ID="Chkselectall" CssClass="TextField" Font-Bold="true" TextAlign="left" runat="server"  Text="Select All" />
        </td>--%>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td>
        
        
        
        
        
        </td>
        
        <%--<td align="right" style="width: 214px">
        
            <asp:UpdatePanel ID="UpdatePanel5" runat="server"><ContentTemplate> 
    <asp:button id="btnaudit" runat="server" CssClass="button1" Text="Audit" OnClick="btnaudit_Click"  /></ContentTemplate></asp:UpdatePanel>

        
</td>--%>
        </tr>
        
        
        
        <tr>
<td align="left"><asp:Label ID="lblagency" runat="server" CssClass="TextField" ></asp:Label></td>
        <td> <asp:UpdatePanel ID="UpdatePanel6" runat="server"><ContentTemplate><asp:TextBox ID="txtagency" CssClass="btext1_bold" runat="server"></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
<td align="left"><asp:Label ID="lbluom" runat="server" CssClass="TextField"  ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel25" runat="server"><ContentTemplate><asp:TextBox ID="txtuom" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
        <td align="left"><asp:Label ID="lblagreedrate" runat="server" CssClass="TextField"></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel38" runat="server"><ContentTemplate><asp:TextBox ID="txtagreedrate" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
       
        
</tr>

<tr>
<td align="left"><asp:Label ID="lblclient" runat="server" CssClass="TextField" ></asp:Label></td>
        <td> <asp:UpdatePanel ID="UpdatePanel4" runat="server"><ContentTemplate><asp:TextBox ID="txtclient" CssClass="btext1_bold" runat="server"></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
        
<td style="width:40px"></td>
 <td align="left"><asp:Label ID="lblpackage" runat="server" CssClass="TextField"></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel31" runat="server"><ContentTemplate><asp:TextBox ID="txtpackage" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:35px"></td>
        <td align="left"><asp:Label ID="lblagreedamount" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel9" runat="server"><ContentTemplate><asp:TextBox ID="txtagreedamount" CssClass="btext1_bold" runat="server"></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>           
</tr>

<tr>
<td align="left"><asp:Label ID="lblpaymode" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel11" runat="server"><ContentTemplate><asp:TextBox ID="txtpaymode" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:35px"></td>        
<td align="left"><asp:Label ID="lblpublichdate" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel32" runat="server"><ContentTemplate><asp:TextBox ID="txtpublishdate" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:35px"></td>
<td align="left"><asp:Label ID="lbldiscount" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel40" runat="server"><ContentTemplate><asp:TextBox ID="txtdiscount" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
             
</tr>

<tr>
<td align="left"><asp:Label ID="lblrono" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel13" runat="server"><ContentTemplate><asp:TextBox ID="txtrono" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
        
<td style="width:40px"></td>
        <td align="left"><asp:Label ID="lblnoofinsertion" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel33" runat="server"><ContentTemplate><asp:TextBox ID="txtnoofinsertion" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
         <td align="left"><asp:Label ID="lblpositionpremium" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel27" runat="server"><ContentTemplate><asp:TextBox ID="txtpositionpremium" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
                
</tr>

<tr>
<td align="left"><asp:Label ID="lblrostatus" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel15" runat="server"><ContentTemplate><asp:TextBox ID="txtrostatus" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
       
<td style="width:40px"></td>
        <td align="left"><asp:Label ID="lblpaid" runat="server" CssClass="TextField"></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel36" runat="server"><ContentTemplate><asp:TextBox ID="txtpaid" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
        
<td style="width:40px"></td>
        <td align="left"><asp:Label ID="lblspecialdiscount" runat="server" CssClass="TextField"></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel39" runat="server"><ContentTemplate><asp:TextBox ID="txtspecialdiscount" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

</tr>

<tr>
<td align="left"><asp:Label ID="lblexecutivename" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel18" runat="server"><ContentTemplate><asp:TextBox ID="txtexecutivename" CssClass="btext1" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
        
<td style="width:40px"></td>
<td align="left"><asp:Label ID="lblcontractname" runat="server" CssClass="TextField"></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel34" runat="server"><ContentTemplate><asp:TextBox ID="txtcontractname" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
<td align="left"><asp:Label ID="lblspacediscount" runat="server" CssClass="TextField"></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel42" runat="server"><ContentTemplate><asp:TextBox ID="txtspacediscount" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

</tr>

<tr>
<td align="left"><asp:Label ID="lbloutstanding" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel20" runat="server"><ContentTemplate><asp:TextBox ID="txtoutstanding" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>        
<td align="left"><asp:Label ID="lblheight" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel29" runat="server"><ContentTemplate><font Class="TextField">&nbsp;H&nbsp;</font><asp:TextBox ID="txtheight" CssClass="btext1_bold" style="width:50px" runat="server" ></asp:TextBox><font Class="TextField">&nbsp;W&nbsp;</font><asp:TextBox ID="txtwidth" style="width:50px;" CssClass="btext1numeric" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
        <td align="left"><asp:Label ID="lblspecialcharge" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel17" runat="server"><ContentTemplate><asp:TextBox ID="txtspecialcharge" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
        
</tr>
<tr>
<td align="left"><asp:Label ID="lblretainername" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel10" runat="server"><ContentTemplate><asp:TextBox ID="txtretainername" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
<td align="left"><asp:Label ID="lbllines" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel30" runat="server"><ContentTemplate><asp:TextBox ID="txtlines" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

 <td style="width:40px"></td>
        <td align="left"><asp:Label ID="lbladdagecomm" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel12" runat="server"><ContentTemplate><asp:TextBox ID="txtaddagecomm" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>       

</tr>

<tr>
<td align="left"><asp:Label ID="lblbookingtype" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel19" runat="server"><ContentTemplate><asp:TextBox ID="txtbookingtype" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
        <td align="left"><asp:Label ID="lblpageposition" runat="server" CssClass="TextField"  ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel26" runat="server"><ContentTemplate><asp:TextBox ID="txtpageposition" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
         <td align="left"><asp:Label ID="lblgrossamt" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate><asp:TextBox ID="txtgrossamt" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
                
</tr>

<tr>
<td align="left"><asp:Label ID="lblcolourtype" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel28" runat="server"><ContentTemplate><asp:TextBox ID="txtcolourtype" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
         <td align="left"><asp:Label ID="lblpositionpre1" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate><asp:TextBox ID="TextBox1" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
        
<td style="width:40px"></td>
        <td align="left"><asp:Label ID="lblretainercommission" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel24" runat="server"><ContentTemplate><asp:TextBox ID="txtretainercommission" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

</tr>

<tr>
<td align="left"><asp:Label ID="lbladcategory" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel21" runat="server"><ContentTemplate><asp:TextBox ID="txtadcategory" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
        
<td style="width:40px"></td>
        <td align="left"><asp:Label ID="lblarea" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel3" runat="server"><ContentTemplate><asp:TextBox ID="txtarea" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
<td align="left"><asp:Label ID="lblagtradediscount" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel23" runat="server"><ContentTemplate><asp:TextBox ID="txtagtradediscount" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
        
</tr>

<tr>
<td align="left"><asp:Label ID="lbladsubcat1" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel235" runat="server"><ContentTemplate><asp:TextBox ID="txtadsubcat1" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
        <td align="left"><asp:Label ID="lblschemetype" runat="server" CssClass="TextField"></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel35" runat="server"><ContentTemplate><asp:TextBox ID="txtschemetype" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
        
<td style="width:40px"></td>
        <td align="left"><asp:Label ID="lblbillamount" runat="server" CssClass="TextField"></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel43" runat="server"><ContentTemplate><asp:TextBox ID="txtbillamount" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

</tr>

<tr>
<td align="left"><asp:Label ID="lbladsubcat2" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel234" runat="server"><ContentTemplate><asp:TextBox ID="txtadsubcat2" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
<td align="left"><asp:Label ID="lblratecode" CssClass="TextField" runat="server"></asp:Label></td>
        <td>
         <asp:UpdatePanel ID="UpdatePanel7" runat="server"><ContentTemplate>
        <asp:TextBox ID="txtratecode" CssClass="btext1" runat="server"></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
<td align="left"><asp:Label ID="lblbillrecamt" CssClass="TextField" runat="server"></asp:Label></td>
        <td>
         <asp:UpdatePanel ID="UpdatePanel5" runat="server"><ContentTemplate>
        <asp:TextBox ID="txtbillrecamt" CssClass="btext1" runat="server"></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

</tr>

<tr>
<td align="left"><asp:Label ID="lbladsubcat3" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel236" runat="server"><ContentTemplate><asp:TextBox ID="txtadsubcat3" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
        <td align="left"><asp:Label ID="lblcardrate" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel8" runat="server"><ContentTemplate><asp:TextBox ID="txtcardrate" CssClass="btext1_bold"  runat="server"></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
        <td style="width:40px"></td>
<td align="left"><asp:Label ID="lblbillbalamt" CssClass="TextField" runat="server"></asp:Label></td>
        <td>
         <asp:UpdatePanel ID="UpdatePanel22" runat="server"><ContentTemplate>
        <asp:TextBox ID="txtbillbalamt" CssClass="btext1" runat="server"></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

</tr>

<tr>
<td align="left"><asp:Label ID="lbladsubcat4" runat="server" CssClass="TextField" ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel14" runat="server"><ContentTemplate><asp:TextBox ID="txtadsubcat4" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
<td align="left"><asp:Label ID="lblcardamount" runat="server" CssClass="TextField"></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel37" runat="server"><ContentTemplate><asp:TextBox ID="txtcardamount" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
        
</tr>
       <tr>
       <td><asp:Label ID="lblaudit" runat="server" CssClass="TextField"></asp:Label></td>
       <td colspan="4"><asp:TextBox ID="txtremarks" TextMode="multiLine" CssClass="btext1_BOOKADI" Width="450px" Enabled="false" Height="50px" runat="server"></asp:TextBox></td>
       <td colspan="2"> <asp:Button ID="btnsave1" runat="server" 
               Width="100" CssClass="button1" Text="Save Comments" /></td>
        <td> <asp:Button ID="btnsub" runat="server" 
               Width="100" CssClass="button1" Text="Submit" /></tr>
              
        <tr>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
    <td align="right" style="width: 214px" >
    
         <asp:Button ID="btnmodify" runat="server" CssClass="button1" Text="Modify" Visible="false" />


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
			<input id="hidden1" value="0" type="hidden" name="hiddenrefresh" runat="server" />
				<input id="hiddenedition" value="0" type="hidden" name="hiddenrefresh" runat="server" />
						<input id="hiddenadcategory" value="0" type="hidden" name="hiddenrefresh" runat="server" />
<input id="hiddensupplement" value="0" type="hidden" name="hiddenrefresh" runat="server" />
<input id="hiddenrtaudit_audit" value="0" type="hidden" name="hiddenrefresh" runat="server" />
<input id="hiddenbran" value="0" type="hidden" name="hiddenbran" runat="server" />
<input id="hiddentalu" value="0" type="hidden" name="hiddentalu" runat="server" />
<input id="ip1" type="hidden" name="ip1" runat="server" />


			
			 </form>
</body>
</html>
