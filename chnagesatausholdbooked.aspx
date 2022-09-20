<%@ Page Language="C#" AutoEventWireup="true" CodeFile="chnagesatausholdbooked.aspx.cs" Inherits="chnagesatausholdbooked" EnableEventValidation="false" %>

<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<script type="text/javascript" language="javascript" src="javascript/popupcalender.js"></script>
<script type="text/javascript" language="javascript" src="javascript/chnagesatausholdbooked.js"></script>
  <script language="javascript" type="text/javascript" src="javascript/popupcalender.js"></script>
      <script language="javascript" type="text/javascript" src="javascript/Validations.js"></script>
      <script language="javascript" type="text/javascript" src="javascript/datevalidation.js"></script>

<link href="css/main.css" type="text/css" rel="stylesheet"/>
    <title>Change Status From Hold TO Booked</title>
</head>
<body  " leftMargin="0" topmargin="0"   onkeydown="javascript:return tabvalue1(event);"  onload="javascript:return clearall();" >
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
     
    
    
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
        
          <div id="div2" style="position: absolute; top: 0px; left: 0px; border: none; display: none;
            z-index: 1; " >
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td style="border: 1px">
                        <asp:ListBox ID="lstexecutive" Width="350px" Height="80px" runat="server" CssClass="btextlist">
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
        
    
    
    
    <table id="OuterTable" width="980" align="center" border="0" cellpadding="0" cellspacing="0">
    <tr >
    <td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Ad Booking Audit"></uc1:topbar></td>
    </tr>
    
    </table>
    
   
  	<table border="0" align="center" width="100%" cellpadding="0" cellspacing="0" style="width:auto;margin:15px 30px;">
                  <tr>
				     <td style="width:27px;"></td>
                     <td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
                     <td style="width:135PX;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Change Status From Hold TO Booked</center></b></td>
                     <td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
					 <td style="width:730px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:770px; height:3px;"></td></tr></table></td>
                   </tr>
            </table>  
    
   <table  style="margin-left:250px">
<tr>



<td align="left">
<asp:Label id="lbDateFrom" runat="server" CssClass="TextField">From Date</asp:Label></td>
<td style="HEIGHT: 25px" align="left">
<asp:TextBox id="txtfrmdate" runat="server" CssClass="btext1" ></asp:TextBox>
<img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txtfrmdate, "mm/dd/yyyy")' onfocus="abc();" height=14 width=14/>
</td>
<td align="left">
<asp:Label id="lbToDate" runat="server" CssClass="TextField">To Date</asp:Label></td>
<td style="HEIGHT: 25px" align="left">

<asp:TextBox id="txttodate1" runat="server" CssClass="btext1" ></asp:TextBox>
<img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txttodate1, "mm/dd/yyyy")' onfocus="abc();" height=14 width=14/>
</td>
</tr>



<tr>
<td align="left"><asp:Label id="lblagency" runat="server" CssClass="TextField">Agency</asp:Label></td>
<td style="HEIGHT: 25px" align="left">
<asp:TextBox id="txtagency1" runat="server" CssClass="dropdown" >
</asp:TextBox>
</td>
<td align="left"><asp:Label id="lblciod" runat="server" CssClass="TextField">CIOid/RECNO</asp:Label></td>
<td style="HEIGHT: 25px" align="left">
<asp:TextBox id="txtciod" runat="server" CssClass="dropdown" >
</asp:TextBox>
</td>
</tr>


<tr>

<td align="left">&nbsp;</td>
<td style="HEIGHT: 25px" align="left">
    &nbsp;</tr>
			
			
<tr>
<td colspan="2" align="right">


<asp:UpdatePanel ID="up60" runat="server"><ContentTemplate> <asp:button id="btnsubmit" runat="server" CssClass="button1" Text="Submit" onclick="btnsubmit_Click" 
        ></asp:button></ContentTemplate></asp:UpdatePanel>
</td>							
</tr>                                          	
                                                      
   </table>
   
 <%--  <table><tr><td >--%>
 
  
    <div id="divgrid1"  align="center"  runat="server" style="display:block; OVERFLOW: auto;width:615px;height:300px;margin-left:200px" >
    
    
   <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
   <asp:DataGrid ID="DataGrid1" runat="server" CssClass="dtGrid"     OnItemDataBound="DataGrid1_ItemDataBound"
            AutoGenerateColumns="False"   
            Width="604px">
     <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
     <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3"></HeaderStyle>
     <Columns>
     <asp:TemplateColumn >
     </asp:TemplateColumn>
         <asp:TemplateColumn HeaderText="Sr. No."></asp:TemplateColumn>
        
         
    
        <asp:BoundColumn DataField="CATEGORY" HeaderText="CATEGORY" SortExpression="Edition_Alias">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
    
          
     <asp:BoundColumn DataField="CIOBOOKING" HeaderText="CIOBOOKING" SortExpression="Edition_Alias">
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
          
          
           <asp:BoundColumn DataField="RONO" HeaderText="RONO" SortExpression="RONO" >
     <ItemStyle HorizontalAlign="Center"></ItemStyle>
      <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
         Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
          </asp:BoundColumn>
    
          
       
			
			
			
			 
			
			<asp:BoundColumn DataField="Insert_Date" HeaderText="Insert_Date">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
          
          
          	
			<asp:BoundColumn DataField="EDITION" HeaderText="EDITION">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
          
          
			
			
			
			
			
			
			<asp:BoundColumn DataField="Insert_Id" HeaderText="Insert_Id" SortExpression="Insert_Id" Visible="false">
			<ItemStyle HorizontalAlign="Center"></ItemStyle>
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
              Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
			</asp:BoundColumn>
  
    
     </Columns>
     </asp:DataGrid>
										
			 </ContentTemplate></asp:UpdatePanel>					
   
   </div>
   
   <table align="center"><tr><td  align="center"> <asp:Button runat="server"  Enabled="false" CssClass="button1" ID="update" Text="Update" /> </td></tr></table>
 
      
     <%--  </td></tr></table>--%>
 
   <input id="hiddendateformat" type="hidden" name="hiddendateformat" runat="server"/>
    <input id="hiddencompcode" type="hidden" size="1" name="hiddencomcode" runat="server"/>
   <input id="hiddenuserid" type="hidden" size="1" name="Hidden1" runat="server"/>
     <input id="Hiddenclientcode" type="hidden" name="hidattach1" runat="server" />
     <input id="Hiddenagencycode" type="hidden" name="hidattach1" runat="server" />
     <input id="hdnglobalid" type="hidden" name="hdnglobalid" runat="server" />
      <input id="hdnexecutive" type="hidden" name="hdnglobalid" runat="server" />
      <input id="hdnclientcode" type="hidden" name="hdnclientcode" runat="server" />
    <input id="hdncode" type="hidden" name="hdncode" runat="server" />
    <input id="hdncodesubcode" type="hidden" name="hdncodesubcode" runat="server" />
     <input id="hdnlength" type="hidden" name="hdncodesubcode" runat="server" />
     
   <%-- </div>--%>
    </form>
</body>
</html>
