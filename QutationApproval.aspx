<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QutationApproval.aspx.cs" Inherits="Qutation_Approval"  EnableEventValidation="false" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Qutation Approval</title>
   
      <link href="css/main.css" type="text/css" rel="stylesheet"/>
	<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>
	<script  type="text/javascript"language="javascript" src="javascript/givepermission.js"></script>

    <script language="javascript"  type="text/javascript" src="javascript/datevalidation.js"></script>
  
<script type="text/javascript"  language="javascript" src="javascript/QutationApproval.js"></script>
       <script type="text/javascript"language="javascript" src="billing/javascript/poprate.js"></script>
</head>
<body onkeydown="javascript:return tabvalue1(event);">
    <form id="form1" method="post"  runat="server">
    <div id="div1" style="position: absolute; top: 0px; left: 0px; border: none; display: none;
            z-index: 1; " >
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td style="border: 1px">
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
        
        
        <div id="div3" style="position: absolute; top: 0px; left: 0px; border: none; display: none;
            z-index: 1;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        
                                <asp:ListBox ID="lstret" Width="254px" Height="65px" runat="server" CssClass="btextlist">
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
        
        
        
        
        
        
        
        
        
        
        
        <div>
    <table id="OuterTable" width="980" align="center" border="0" cellpadding="0" cellspacing="0">
    <tr >
    <table id="Table1" width="980" align="center" border="0" cellpadding="0" cellspacing="0">
    <tr >
    <td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Rate Audit"></uc1:topbar></td>
    </tr>
    <tr>
        <td style="width: 966px">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
                             <div id="divagency" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:0;">
<table cellpadding="0" cellspacing="0"><tr><td>
<asp:UpdatePanel  ID="UpdatePanel16" runat="server">
<ContentTemplate>
<asp:ListBox ID="ListBox1" Width="350px" Height="80px" runat="server" CssClass="btextlist" ></asp:ListBox>
</ContentTemplate></asp:UpdatePanel>

</td></tr></table></div>       
                        
                        
                        
                        
                        
                        
		 
<div id="div2" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:0;">
<table cellpadding="0" cellspacing="0"><tr><td>
<asp:UpdatePanel  ID="UpdatePanel71" runat="server">
<ContentTemplate>
<asp:ListBox ID="ListBox2" Width="350px" Height="80px" runat="server" CssClass="btextlist" ></asp:ListBox>
</ContentTemplate></asp:UpdatePanel>

</td></tr></table></div> 


                                                      
                                                      
                                                        <div id="div4" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
      <table cellpadding="0" cellspacing="0"><tr><td>
      <asp:ListBox ID="lstexecutive" Width="350px" Height="75px" runat="server" CssClass="btextlist" >
      </asp:ListBox>
      </td></tr></table></div>
     
      <div id="div5" style="position:absolute;top:0px;left:0px;border:none;display:none;z-index:1;">
      <table cellpadding="0" cellspacing="0"><tr><td>
      <asp:ListBox ID="lstretainer" Width="350px" Height="75px" runat="server" CssClass="btextlist" ></asp:ListBox>
      </td></tr></table></div>
            
            
     <table align="center">
     <tr>
     <td><asp:Label ID="lbladtype" runat="server" CssClass="TextField"> Ad Type<font color="red">*</font></asp:Label></td>
     <td><asp:DropDownList ID="drpadtype" runat="server" CssClass="dropdown"></asp:DropDownList></td>
 
   
     
      
                                                        
  
                  

    
   <td align="left"><asp:Label id="lblagency" runat="server" CssClass="TextField"></asp:Label></td>
                <td ><asp:TextBox id="txtagency1" runat="server" CssClass="btext1" ></asp:TextBox></td>     
                
    	<td align="left" ><asp:Label id="lblclient" runat="server" CssClass="TextField"></asp:Label></td>
	             <td align="left"><asp:TextBox CssClass="btext1" id="txtclient1" runat="server" ></asp:TextBox></td>
     
    
     
     <td align="left" ><asp:Label id="lblret" runat="server" CssClass="TextField"></asp:Label></td>
	             <td align="left"><asp:TextBox CssClass="btext1" id="dpretainer" runat="server" ></asp:TextBox></td>
 
 
 
 <%--<td align="left"><asp:Label id="Label4" runat="server" CssClass="TextField">Retainer</asp:Label></td>
	<td >
                                                            
<asp:TextBox ID ="dpretainer" runat="server" CssClass="btext1" onkeypress="javascript:return blankf2field()"  onkeydown="javascript:return Enterf2(event);"></asp:TextBox>
                        
 </td>--%>
 
 </tr>
     <tr>
 
 
                <td align="left"><asp:Label id="lblexec" runat="server" CssClass="TextField"></asp:Label></td>
                <td ><asp:TextBox id="txtexecname" runat="server" CssClass="btext1" ></asp:TextBox></td>  
                
     
   
      <td ><asp:Label ID="lblfromdate" runat="server" CssClass="TextField"></asp:Label></td>
       <td ><asp:TextBox ID="txtvalidityfrom" runat="server" CssClass="btext1" Enabled="true" MaxLength="10"></asp:TextBox>
     
      <img alt ='Images/cal1.gif' src='Images/cal1.gif'  onclick='popUpCalendar(this,form1.txtvalidityfrom,"mm/dd/yyyy")' height="14" width="14" />
			</td>
	
       <td><asp:Label ID="lbltilldate" runat ="server" CssClass="TextField" Align="right"></asp:Label></td>
       <td> <asp:textbox id="txttilldate" runat="server" CssClass="btext1" Enabled="true" MaxLength="10" ></asp:textbox>
       
    <img alt = 'Images/cal1.gif' src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txttilldate,"mm/dd/yyyy")' height="14" width="14"/>
		
      </td>
   
                                                        
       <td><asp:Label ID="Label2" runat="server" CssClass="TextField">Category<font color="red">*</font></asp:Label></td>
     <td><asp:DropDownList ID="drprate" runat="server" CssClass="dropdown"></asp:DropDownList></td></tr>
     <tr>
   
      <%-- <td></td>--%>
      <%-- <tr><td class="style1"></td>--%>
       <td><asp:Label ID="Label3" runat="server" CssClass="TextField"> Audit Type</asp:Label></td>
     <td><asp:DropDownList ID="drpaudit" runat="server" CssClass="dropdown">
     <asp:ListItem Value="0" Text="Select"></asp:ListItem>
     <asp:ListItem Value="U" Text="UnAudit"></asp:ListItem>
     <asp:ListItem Value="A" Text="Approve"></asp:ListItem>     
     <asp:ListItem Value="N" Text="Reject"></asp:ListItem>
     </asp:DropDownList></td></tr>
     
     
    
     </tr>
  
          
         	
													
              <tr><td>
              <asp:UpdatePanel ID="update101" runat ="server" >
              <ContentTemplate >
             
              <asp:button id="btnsubmit" runat="server" CssClass="button1" Text="Submit" OnClick="btnsubmit_Click"></asp:button>
                           <asp:Button ID="btnexit" runat="server" CssClass="button1" Text="Exit" ></asp:Button>
               </ContentTemplate>
              </asp:UpdatePanel>

              </td>
              <td align="right" colspan="1"></td>
          </tr>
     </table>
     </td>
     </tr>
     <tr>
     <td>
    
     

   <table cellpadding="0" cellspacing="0" width="100%"><tr valign="top" ><td align="center" style="height: 219px">
     <div id="divgrid1"  runat="server" style="display:block;OVERFLOW: auto; vertical-align:top; WIDTH: 950px;height:200PX">
     <table id="Table2" align="center">
     <tr>
       
     <td align="center">
     <asp:UpdatePanel ID="UpdatePanel45" runat ="server" >
     <ContentTemplate >
   
     <asp:DataGrid ID="DataGrid1" runat="server" CssClass="dtGrid"  Width="950px"  AutoGenerateColumns="False" OnItemDataBound="DataGrid1_ItemDataBound" >
     <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
     <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></HeaderStyle>
     <Columns>
    
         
         
         
             <asp:BoundColumn  HeaderText="S.No" >
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
			
			
			 
			
     <asp:BoundColumn DataField="TEMPID" HeaderText="Booking Id" SortExpression="Edition_Alias">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
          
          
          
          
          <asp:BoundColumn DataField="agency" HeaderText="Agency" SortExpression="Date_Edition">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
             Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
		
			
		
      <asp:BoundColumn SortExpression="client" DataField="client" HeaderText="Client" ReadOnly="True" Visible="true">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
          
          
          
          <asp:BoundColumn SortExpression="INSERTION" DataField="INSERTION" HeaderText="INSERTION" ReadOnly="True" Visible="true">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
          
          
          <asp:BoundColumn SortExpression="QUOTATIONFLAG" DataField="QUOTATIONFLAG" HeaderText="QUOTATIONFLAG" ReadOnly="True" Visible="false">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
          
      
            
            <asp:TemplateColumn  >
            
           <%-- <HeaderTemplate>
<input id="Checkbox4" onclick="SelectHi('DataGrid1',this,'Checkbox4');" type="checkbox" name="Checkbox4" runat="server"/>                    </HeaderTemplate>
           
            --%>
																<%--<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"   > 
																
																</HeaderStyle>--%>
																<%--<ItemStyle HorizontalAlign="Center" Width="20px" VerticalAlign="Middle" ></ItemStyle>
																<ItemTemplate >
																	<asp:CheckBox ID="CheckBox1" CssClass="TextField1" Runat="server"  />
																</ItemTemplate>--%>
															</asp:TemplateColumn>
															
															
															
															
															
															
															
										

          
          
                           
                     
                 

          
          
     </Columns>
     </asp:DataGrid>
       </ContentTemplate>
     </asp:UpdatePanel>
    
    
     </td>
     </tr>
     </table>
     
    </div>
     </td></tr></table>
      </td>
     </tr>
 
    <%-- 
     <div id="maintbl1" runat="server" align="center">--%>
        
     </tr>
    </table>
    </div>
    
     

  
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
       <td><asp:Label ID="lblaudit" runat="server" CssClass="TextField"></asp:Label></td>
       <td colspan="4"><asp:UpdatePanel ID="UpdatePanel44" runat="server"><ContentTemplate><asp:TextBox ID="txtremarks" TextMode="multiLine" CssClass="btext1_BOOKADI" Width="450px" Enabled="false" Height="50px" runat="server"></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
       <td colspan="2"> <%--<asp:Button ID="btnsave1" runat="server" 
               Width="100" CssClass="button1" Text="Apporve" />
         <asp:Button ID="btnsub" runat="server" 
               Width="100" CssClass="button1" Text="Reject" />--%>
            <asp:Label id="lblapr" runat="server" CssClass="TextField"></asp:Label>
            <asp:RadioButton ID="rbapr" GroupName="a" runat="server"  CssClass="TextField" Enabled="true"  TextAlign="Left" />
            <asp:Label id="lbrej" runat="server" CssClass="TextField"></asp:Label>
            <asp:RadioButton ID="rbrej" GroupName="a" runat="server" Enabled="true" CssClass="TextField" 
             TextAlign="Left" /></td><td colspan='6'>
              <asp:UpdatePanel ID="UpdatePanel41" runat ="server">
              <ContentTemplate >
             <%--<asp:Button ID="btnsave1" runat="server" CssClass="button1" Text="Save" Enabled="false" onclick="btnsave1_Click" /><asp:Button ID="btnmail" runat="server"  CssClass="button1" Text="Send Mail" Enabled="false" onclick="btnsave1_Click" />
                 
                  <asp:Button ID="btnautomail" runat="server"  CssClass="button1" 
                      Text="Approval Report" Width="86px"   /></ContentTemplate></asp:UpdatePanel></td></tr>--%>
        
        <asp:Button ID="btnsave1" runat="server"  CssClass="button1" 
                      Text="Approval Report" Width="86px" onclick="btnsave1_Click"    /></ContentTemplate></asp:UpdatePanel>
        <tr>
<td align="left"><asp:Label ID="lblagency1" runat="server" CssClass="TextField" ></asp:Label></td>
        <td> <asp:UpdatePanel ID="UpdatePanel6" runat="server"><ContentTemplate><asp:TextBox ID="txtagency" CssClass="btext1_bold" runat="server"></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
<td align="left"><asp:Label ID="lbluom" runat="server" CssClass="TextField"  ></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel25" runat="server"><ContentTemplate><asp:TextBox ID="txtuom" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>

<td style="width:40px"></td>
        <td align="left"><asp:Label ID="lblagreedrate" runat="server" CssClass="TextField"></asp:Label></td>
        <td><asp:UpdatePanel ID="UpdatePanel38" runat="server"><ContentTemplate><asp:TextBox ID="txtagreedrate" CssClass="btext1_bold" runat="server" ></asp:TextBox></ContentTemplate></asp:UpdatePanel></td>
       
        
</tr>

<tr>
<td align="left"><asp:Label ID="lblclient1" runat="server" CssClass="TextField" ></asp:Label></td>
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
    
    <input id="hiddencompcode" type="hidden" size="1" name="hiddencomcode" runat="server"/>
			<input id="hiddenuserid" type="hidden" size="1" name="Hidden1" runat="server"/> 
			<input id="hiddenDateFormat" type="hidden" size="1" name="Hidden2" runat="server"/>
			<input id="hiddenusername" type="hidden" size="2" name="Hidden1" runat="server"/>
			<input id="hiddenbookingid" type="hidden" name="hiddenbookingid" runat="server" />
			<input id="hiddenrowcount" type="hidden" name="hiddenrowcount" runat="server" />
			<input id="hdnbranch" type="hidden" name="hdnbranch" runat="server" />
			<input id="hdnfdate" type="hidden" name="hiddenrowcount" runat="server" />
			<input id="hdntdate" type="hidden" name="hiddenrowcount" runat="server" />
			<input id="hdnbasedon" type="hidden" name="hiddenrowcount" runat="server" />
			<input id="hidattach1" type="hidden" name="hidattach1" runat="server" />
			<input id="Hiddenagencycode" type="hidden" name="hidattach1" runat="server" />
			<input id="Hiddenexecutivecode" type="hidden" name="hidattach1" runat="server" />
			<input id="Hiddenclientcode" type="hidden" name="hidattach1" runat="server" />
			<input id="Hiddencentercode" type="hidden" name="hidattach1" runat="server" />
			<input id="hiddenretainercode" type="hidden" name="hidattach1" runat="server" />
			<input id="hiddenretainer" type="hidden"   runat="server" />
                <input id="hiddenretainertxt"   type="hidden"   runat="server" />
			<input id="hidden_client" type="hidden"   runat="server" />
			<input id="hidden_agency" type="hidden"   runat="server" />
			<input id="hdnexecutivetxt" type="hidden" size="1" name="hiddenbranch1" runat="server"/>
			  <input type="hidden" id="hiddencioidformat" runat="server" />
			
    </form>
</body>

</html>
