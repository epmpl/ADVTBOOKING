
<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="ContractDetail.aspx.cs" Inherits="ContractDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Contract Master Contract Details</title>
    <link href="css/main.css" type="text/css" rel="stylesheet" />
    <script language="javascript" src="javascript/Contract.js" type="text/javascript"></script>
    <script language="javascript" src="javascript/gridsize.js" type="text/javascript"></script>
    <script language="javascript" src="javascript/entertotab.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
    
    function notchar2()
{
//alert(event.keyCode);

if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9)||(event.keyCode==46))
{
return true;
}
else
{
return false;
}
}

function notchar()
{
//alert(event.keyCode);

if((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==127)||(event.keyCode==8)||(event.keyCode==9))
{
return true;
}
else
{
return false;
}
}



</script>
   <style type="text/css">
    
.animatedtabs{
border-bottom: 1px solid gray;
overflow: hidden;
width: 100%;
font-size: 14px; /*font of menu text*/
}


.animatedtabs ul{
list-style-type: none;
margin: 0;
margin-left: 10px; /*offset of first tab relative to page left edge*/
padding: 0;
}

.animatedtabs li{
float: left;
margin: 0;
padding: 0;
}

.animatedtabs a{
float: left;
position: relative;
top: 5px; /* 1) Number of pixels to protrude up for selected tab. Should equal (3) MINUS (2) below */
background: url(images/tab-blue-left.gif) no-repeat left top;
margin: 0;
margin-right: 3px; /*Spacing between each tab*/
padding: 0 0 0 9px;
text-decoration: none;

}

.animatedtabs a span{
float: left;
position: relative;
display: block;
background: url(images/tab-blue-right.gif) no-repeat right top;
padding: 5px 14px 3px 5px; /* 2) Padding within each tab. The 3rd value, or 3px, should equal (1) MINUS (3) */
font-weight: bold;
color: black;
}

/* Commented Backslash Hack hides rule from IE5-Mac \*/
.animatedtabs a span {float:none;}
/* End IE5-Mac hack */


.animatedtabs .selected a{
background-position: 0 -125px;
top: 0;
}

.animatedtabs .selected a span{
background-position: 100% -125px;
color: black;
padding-bottom: 8px; /* 3) Bottom padding of selected tab. Should equal (1) PLUS (2) above */
top: 0;
}

.animatedtabs a:hover{
background-position: 0% -125px;
top: 0;
}

.animatedtabs a:hover span{
background-position: 100% -125px;
padding-bottom: 8px; /* 3) Bottom padding of selected tab. Should equal (1) PLUS (2) above */
top: 0;
}

</style>
 
</head>
<body onkeydown="javascript:return tabvalue1(event);" onkeypress="eventcalling(event);">
    <form id="form1" runat="server">
    <div id="divcommon" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1; " >
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:ListBox ID="lstcommon" Width="350px" Height="80px" runat="server" CssClass="btextlist">
                        </asp:ListBox></td>
                </tr>
            </table>
        </div>
         <div id="divbtb" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1; " >
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:ListBox ID="lstbtb" Width="350px" Height="80px" runat="server" CssClass="btextlist">
                        </asp:ListBox></td>
                </tr>
            </table>
        </div>
          <div id="divros" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1; " >
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:ListBox ID="lstros" Width="350px" Height="80px" runat="server" CssClass="btextlist">
                        </asp:ListBox></td>
                </tr>
            </table>
        </div>
    	<div class="animatedtabs">
<ul>
<li class="selected" id="an_print"><a href="#" style="cursor:hand"   title="Print" onclick="return openPrint();"><span class="TextField">Print</span></a></li>
<li id="an_elec"><a href="#"  style="cursor:hand" title="Electronics" onclick="return openElectronics();"><span class="TextField">Electronics</span></a></li>
<li id="an_web"><a href="#" style="cursor:hand"  title="Web" onclick="return openWeb();"><span class="TextField">Web</span></a></li>
</ul>
</div>
<table border="1" style="border-color:blue"><tr><td>
    <div id="divprint" style="display:none;">
    
        <table align="center" >
            <tr>
              <td style="width: 144px; height: 21px;" >
                                                <asp:Label ID="lbadtype" runat="server" CssClass="TextField"></asp:Label></td>
                                            <td  style="height: 21px" >
                                                    <asp:DropDownList ID="drpadtype" runat="server" CssClass="dropdown" Enabled="False">
                                                    </asp:DropDownList>
                                               
                                            </td>
               
                <td style="height: 21px" >
               
                    <asp:Label ID="Color" runat="server" CssClass="TextField"></asp:Label>
                   
                    </td>
                    
                <td style="height: 21px" >
              
                    <asp:DropDownList ID="drpcolor" runat="server" CssClass="dropdown" AutoPostBack="false" >
                    </asp:DropDownList>
                  
                    </td>
                <td style="height: 21px" >
                
                    <asp:Label ID="volumeunit" runat="server" CssClass="TextField"></asp:Label>
                   
                    </td>
                <td style="height: 21px" > 
                   
                <asp:DropDownList ID="drpuom" runat="server" CssClass="dropdown" AutoPostBack="false">
                    </asp:DropDownList>
                    
                  
                    
                    
                    </td>
            </tr><tr> <td > 
                <asp:Label ID="packagecode" runat="server" CssClass="TextField"></asp:Label>
                   
                    </td>
                <td align="left">
                <asp:DropDownList ID="drppackagecode" runat="server" CssClass="dropdown" AutoPostBack="false" >
                    </asp:DropDownList>
                  
                    </td>
                     <td >
                    <asp:Label ID="agencycategory" runat="server" CssClass="TextField"></asp:Label>
                  
                    </td>
                <td style="height: 21px" >
                    <asp:DropDownList ID="drpadvcat" runat="server" CssClass="dropdown">
                    </asp:DropDownList>
                  
                    </td>
                    
                <td > 
              
                    <asp:Label ID="Volumedisc" runat="server" CssClass="TextField"></asp:Label>
                  
                    </td>
                <td >
                    <asp:TextBox ID="txtvoldisc" onkeypress="return notchar2();" runat="server" CssClass="btext1" MaxLength="10"></asp:TextBox>
                  
                    </td>
                    </tr>
            <tr><td >
                  
                <asp:Label ID="bookedfor" runat="server" CssClass="TextField"></asp:Label>
                  
                    </td> <td colspan="3">
                <asp:TextBox ID="drpbooked" runat="server" CssClass="btextbig" TextMode="MultiLine" Enabled="False"></asp:TextBox>
                 
                </td>
                 <td >
                <asp:Label ID="VolumeBilled" runat="server" CssClass="TextField"></asp:Label> 
                  
                    </td>
                <td >
               <asp:TextBox ID="txtvolbilled" onkeypress="return notchar2();" runat="server" CssClass="btext1" MaxLength="10"></asp:TextBox>
                 
                    </td>
                </tr>
            <tr>
                <td>
                    <asp:Label ID="lbdisc" runat="server" CssClass="TextField"></asp:Label></td>
                <td>
             
                        <asp:DropDownList ID="drpdisc" runat="server" CssClass="dropdown">
                        <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                        <asp:ListItem Value="1" >Free</asp:ListItem>
                        <asp:ListItem Value="2" >Discounted</asp:ListItem>
                         <asp:ListItem Value="3" >Fixed Rate</asp:ListItem>
                        </asp:DropDownList>
                </td>
                <td>
                  
                    <asp:Label ID="DealRate" runat="server" CssClass="TextField"></asp:Label>
                    
                    </td>
                <td>
                
                        <asp:TextBox ID="txtdealrate" runat="server" CssClass="btext1" MaxLength="10" onkeypress="return notchar2();"></asp:TextBox>
                  
                </td> <td> <asp:Label ID="lbldiscamt" runat="server" Text="Discount Per." CssClass="TextField"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="txtdiscamount" runat="server" CssClass="btext1" style="width:50px;text-align:right;" onkeypress="return notchar2();" Enabled="False"></asp:TextBox></td>




               
            </tr>
            <tr>
              
                <td  >
                    <asp:Label ID="PremiumCode" runat="server" CssClass="TextField"></asp:Label>
                 
                    </td>
                <td >
                    <asp:DropDownList ID="drppremium" runat="server" CssClass="dropdown" >
                    </asp:DropDownList>
                   
                    </td>
                  <td > 
                    <asp:Label ID="lbdeviation" runat="server" CssClass="TextField"></asp:Label></td>
                <td > 
                  
                    <asp:TextBox ID="txtdeviation" onkeypress="return notchar2();" runat="server" CssClass="btext1" MaxLength="5" Enabled="False"></asp:TextBox>
                  
                    </td> <td><asp:Label ID="lbldisctype" runat="server" Text="Discount Type" CssClass="TextField"></asp:Label>
                    </td>
                <td>
                <asp:DropDownList ID="drpdisctype" runat="server" CssClass="dropdown">
                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                <asp:ListItem Value="1" Text="Discount On Bill"></asp:ListItem>
                <asp:ListItem Value="2" Text="Discount through Credit Note"></asp:ListItem>
                    </asp:DropDownList>
                </td>

   
            </tr>
            <tr>
                <td  > 
                    <asp:Label ID="CardPremium" runat="server" CssClass="TextField"></asp:Label></td>
                <td >
                    <asp:TextBox ID="txtcardpremium" onkeypress="return notchar2();" runat="server" CssClass="btext1" MaxLength="10"></asp:TextBox>
                 
                    </td>
                     <td >
               
                    <asp:Label ID="CardRate" runat="server" CssClass="TextField"></asp:Label>
                 
                    </td>
                <td > 
              
                    <asp:TextBox ID="txtcardrate" onkeypress="return notchar2();" runat="server" CssClass="btext1" MaxLength="5"></asp:TextBox>
                   
                    </td>
          
              <td >  <asp:Label ID="lblsizefrom" runat="server" Text="Min Size" CssClass="TextField"></asp:Label>
                    </td>
                <td > 
                 <asp:TextBox ID="txtsizefrom" onkeypress="return notchar2();" runat="server" CssClass="btext1" MaxLength="10"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td  >
                    <asp:Label ID="DealPremium" runat="server" CssClass="TextField"></asp:Label></td>
                <td >
                  
                    <asp:TextBox ID="txtdealpremium" onkeypress="return notchar2();" runat="server" CssClass="btext1" MaxLength="10"></asp:TextBox>
                  
                    </td>
                  <td >
               <asp:Label ID="Volumefrom" runat="server" CssClass="TextField"></asp:Label>
                    </td>
                <td > 
                <asp:TextBox ID="txtvalfrom" onkeypress="return notchar2();" runat="server" CssClass="btext1" MaxLength="10"></asp:TextBox>
                   
                    </td>
              <td >  <asp:Label ID="lblsizeto" runat="server" Text="Max Size" CssClass="TextField"></asp:Label>
                    </td>
                <td > 
                 <asp:TextBox ID="txtsizeto" onkeypress="return notchar2();" runat="server" CssClass="btext1" MaxLength="10"></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <td  > 
                    <asp:Label ID="editionaldisc" runat="server" CssClass="TextField"></asp:Label></td>
                <td > 
             <asp:DropDownList ID="drpratecode" runat="server" CssClass="dropdown">
                    </asp:DropDownList>
                  
                    </td>
              <td >
                <asp:Label ID="Volumeto" runat="server" CssClass="TextField"></asp:Label>
                   
                    </td>
                <td >
                <asp:TextBox ID="txtvalto" onkeypress="return notchar2();" runat="server" CssClass="btext1" MaxLength="10"></asp:TextBox>
                 
                    </td>
                <td> <asp:Label ID="lbquantity" runat="server" CssClass="TextField"></asp:Label></td><td> 
                        <asp:TextBox ID="txtquantity" runat="server" CssClass="btext1" MaxLength="5" onkeypress="return notchar();"></asp:TextBox>
                  
                    </td>
            </tr>
          
          
            <tr>
               <td >
                <asp:Label ID="lbcurr" runat="server" CssClass="TextField"></asp:Label>
                    </td>
                <td >
                <asp:DropDownList ID="drpcurr" runat="server" CssClass="dropdown" Enabled="False">
                </asp:DropDownList>
                
                    </td>
                
                <td>
                    <asp:Label ID="lbtotal" runat="server" CssClass="TextField"></asp:Label></td>
                <td>
             
                        <asp:TextBox ID="txttotal" runat="server" CssClass="btext1" onkeypress="return notchar2();" Enabled="False"></asp:TextBox>
                
                </td>
               <td > 
                    <asp:Label ID="lbweight" runat="server" CssClass="TextField"></asp:Label></td>
                <td >
                        <asp:TextBox ID="txtweight" runat="server" CssClass="btext1" MaxLength="5" onkeypress="return notchar2();"></asp:TextBox>
                 
                    </td>
            </tr>
              
                                        <tr> <td ><asp:label id="lbldealstart" runat="server" Text="Deal Start" CssClass="TextField"></asp:label></td> <td><asp:DropDownList ID="drpdealstrt" runat="server" CssClass="dropdown">
                                                    <asp:ListItem Value="A">After Target Achived</asp:ListItem>
                                                    <asp:ListItem Value="B">From Begining</asp:ListItem></asp:DropDownList></td>
                                             
                                            <td ><asp:label id="lblincentive" runat="server" CssClass="TextField"></asp:label></td>
                                            <td><asp:TextBox ID="txtincentive" runat="server" CssClass="btext1" onkeypress="return notchar2();" ></asp:TextBox></td>
                                            <td ><asp:label id="lblinsertion" runat="server" Text="No. Of Insertion" CssClass="TextField"></asp:label></td>
                                            <td><asp:TextBox ID="txtinsertion" runat="server" CssClass="btext1" onkeypress="return notchar2();" ></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                                <td ><asp:label id="lblcommallow" runat="server" Text="Commision Allow" CssClass="TextField"></asp:label></td>
                                                <td><asp:DropDownList ID="drpcommallow" runat="server" CssClass="dropdown">
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N">No</asp:ListItem></asp:DropDownList></td>
                                              <td>
                    <asp:Label ID="approved" runat="server" CssClass="TextField"></asp:Label></td>
                <td>
              
                        <asp:CheckBox ID="ckbapproved" runat="server" CssClass="TextField" />
                 
                </td>
                                           <td rowspan="2" valign="top"> <asp:label id="lblday" runat="server" Text="Day" CssClass="TextField"></asp:label></td>
                                        <td rowspan="2">
                                        <asp:ListBox ID="drpday" runat="server" CssClass="dropdown" Enabled="False">
                                        <asp:ListItem Value="0" Text="Select Day"></asp:ListItem>
                                        <asp:ListItem Value="sun" Text="SUN"></asp:ListItem>
                                        <asp:ListItem Value="mon" Text="MON"></asp:ListItem>
                                        <asp:ListItem Value="tue" Text="TUE"></asp:ListItem>
                                        <asp:ListItem Value="wed" Text="WED"></asp:ListItem>
                                        <asp:ListItem Value="thu" Text="THU"></asp:ListItem>
                                        <asp:ListItem Value="fri" Text="FRI"></asp:ListItem>
                                        <asp:ListItem Value="sat" Text="SAT"></asp:ListItem>
                </asp:ListBox>
                                            </td>    
                                                
                                                
                                        </tr>
            <tr>
                <td >
                    <asp:label id="lblremarks" runat="server" Text="Remarks" CssClass="TextField"></asp:label></td>
                <td colspan="3">
                   <asp:TextBox ID="txtremark"  runat="server" CssClass="btext1" Enabled="False" MaxLength="1000" Width="458px"></asp:TextBox></td>
               
                
            </tr>
            <tr>
                <td style="height: 21px">
                </td>
                <td style="height: 21px">
                </td>
                <td style="height: 21px">
                </td>
                <td style="height: 21px">
                </td>
                <td style="height: 21px">
                </td>
                <td style="height: 21px">
                </td>
            </tr>
            <tr>
                <td style="display:none">
              
                    <asp:Label ID="publication" runat="server" CssClass="TextField"></asp:Label>
                    
                </td>
                <td style="display:none">
             
                    <asp:DropDownList ID="drppublication" runat="server" CssClass="dropdown" AutoPostBack="false" >
                    </asp:DropDownList>
                  
                </td>
                <td style="display:none">
             
                <asp:Label ID="suppliment" runat="server" CssClass="TextField"></asp:Label>
                 
                </td>
                <td style="display:none">
                
                <asp:DropDownList ID="drpsuppliment" runat="server" CssClass="dropdown">
                    </asp:DropDownList>
                   
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="display:none">
               
                <asp:Label ID="edition" runat="server" CssClass="TextField"></asp:Label>
                   
                </td>
                <td style="display:none">
            
                <asp:DropDownList ID="drpedition" runat="server" CssClass="dropdown" AutoPostBack="false" >
                    </asp:DropDownList>
                 
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="display:none">
                 
                            <asp:Label ID="CYOP" runat="server" CssClass="TextField"></asp:Label>
                       
                </td>
                <td style="display:none">
                   
                            <asp:CheckBox ID="chbcyop" runat="server" CssClass="TextField" />
                       
                </td>
                <td><input id="hiddenagency" runat="server" type="hidden" /></td>
                <td><input id="hiddenclient" runat="server" type="hidden" /></td>
                <td><input id="hiddenproduct" runat="server" type="hidden" /></td>
                <td>
                </td>
            </tr>
            <tr>
                <td >
                    <input id="hiddendealcode" runat="server" type="hidden" />
                    <input id="hiddenadtype" runat="server" type="hidden" /></td>
                <td>
                    <input id="hiddencompcode" runat="server" type="hidden" />
                    <input id="hiddenfromdate" runat="server" type="hidden" /></td>
                <td><input id="hiddentodate" runat="server" type="hidden" />
                    <input id="hiddenuserid" runat="server" type="hidden" /></td>
                <td><input id="hiddenvalue" runat="server" type="hidden" />
                    <input id="hiddensavemod" runat="server" type="hidden" /></td>
                <td><input id="hiddenvolume" runat="server" type="hidden" />
                    <input id="hiddendeal" runat="server" type="hidden" />
                     <input id="drppackagecode_var" runat="server" type="hidden" />
                      <input id="drpadvcat_var" runat="server" type="hidden" />
                       <input id="drpuom_var" runat="server" type="hidden" />
                        <input id="drppremium_var" runat="server" type="hidden" />
                        <input id="drppackagecodetext_var" runat="server" type="hidden" />
                      <input id="drpadvcattext_var" runat="server" type="hidden" />
                       <input id="drpuomtext_var" runat="server" type="hidden" />
                        <input id="drppremiumtext_var" runat="server" type="hidden" />
                        </td>
                <td align="right">
                    <asp:Button ID="btnselect" runat="server" CssClass="button1" Text="Save" OnClick="btnselect_Click"  /><asp:Button
                        ID="btnclear" runat="server" CssClass="button1" Text="Clear"  />
                      
                        
                        </td>
            </tr>
        </table>
    
    
    
    
       <div id="firgri" runat="server" style="OVERFLOW: auto; WIDTH: 960px; HEIGHT: 176px">
   
                <asp:datagrid  ID="GridView1" runat="server" AutoGenerateColumns="False" OnItemDataBound="GridView1_ItemDataBound" AllowSorting="True" CssClass="dtGrid" OnSortCommand="GridView1_SortCommand"    >
                <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
                <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3" />
                    <Columns>
                        <asp:TemplateColumn HeaderText="New"></asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Modify"></asp:TemplateColumn>
                        <asp:BoundColumn HeaderText="Ad. Category" DataField="Advcategory" SortExpression="Advcategory" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Package Name" DataField="packagecode" SortExpression="packagecode" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Package Description" DataField="Bookedfor" SortExpression="Bookedfor" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Publication" DataField="publication" SortExpression="publication" Visible="False" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Suppliment" DataField="suppliment" SortExpression="suppliment" Visible="False" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Edition" DataField="edition" SortExpression="edition" Visible="False" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Cyop" HeaderText="CYOP" SortExpression="Cyop" Visible="False"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Hue" DataField="color" SortExpression="color" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Card Rate" DataField="cardrate" SortExpression="cardrate" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Contract  Rate" DataField="Dealarte" SortExpression="Dealarte" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="deviation" HeaderText="Deviation" SortExpression="deviation">
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Premium Name" DataField="premiumcode" SortExpression="premiumcode" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Card Premium" DataField="cardpremium" SortExpression="cardpremium" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Contract Premium" DataField="dealpremium" SortExpression="dealpremium" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="UOM" DataField="Uom" SortExpression="Uom" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Volume Billed" DataField="volumebilled" SortExpression="volumebilled" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Volume disc." DataField="volumedisc" SortExpression="volumedisc" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="currency" HeaderText="Currency Type" SortExpression="currency">
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Value From" DataField="valuefrom" SortExpression="valuefrom" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Value To" DataField="valueto" SortExpression="valueto" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="convertrate" HeaderText="Total Rate" SortExpression="convertrate">
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Rate_code" HeaderText="Rate Code" SortExpression="Rate_code">
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="approved" HeaderText="Approved" SortExpression="approved">
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="quantity" HeaderText="Quantity" SortExpression="quantity">
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="weight" HeaderText="Weight" SortExpression="weight">
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="discounted" HeaderText="Disc. Applied" SortExpression="discounted">
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ContractCode" ReadOnly="True" Visible="False"  />
                        <asp:BoundColumn HeaderText="Deal No" ReadOnly="True" Visible="False" DataField="ContractCode" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="SIZEFROM" HeaderText="Size From"></asp:BoundColumn>
                        <asp:BoundColumn DataField="SIZETO" HeaderText="Size To"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DISCTYPE" HeaderText="Disc Type"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DISCPER" HeaderText="Disc Per"></asp:BoundColumn>
                        <asp:BoundColumn DataField="INSERTION" HeaderText="Insertion"></asp:BoundColumn>
                        <asp:BoundColumn DataField="REMARKS" HeaderText="Remarks"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DAYNAME" HeaderText="Day"></asp:BoundColumn>
                         <asp:BoundColumn DataField="COMMITION_ALLOW" HeaderText="COMMITION_ALLOW"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DEAL_START" HeaderText="DEAL_START"></asp:BoundColumn>
                    </Columns>
                </asp:datagrid> 
          </div>
            <!--/*****************8*****************-->
            
            <div id="secgri" runat="server"  style="OVERFLOW: auto; WIDTH: 955px; HEIGHT: 176px">
     
                <asp:datagrid  ID="Datagrid1" runat="server" AutoGenerateColumns="False" OnItemDataBound="Datagrid1_ItemDataBound" AllowSorting="True" CssClass="dtGrid" OnSortCommand="GridView1_SortCommand"    >
                <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
                <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3" />
                    <Columns>
                        <asp:BoundColumn HeaderText="Ad. Category" DataField="Advcategory" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Package Name" DataField="packagecode" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Package Description" DataField="Bookedfor" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Publication" DataField="publication" Visible="False" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Suppliment" DataField="suppliment" Visible="False" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Edition" DataField="edition" Visible="False" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Cyop" HeaderText="CYOP" SortExpression="Cyop" Visible="False"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Hue" DataField="color" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Card Rate" DataField="cardrate" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Contract  Rate" DataField="Dealarte" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="deviation" HeaderText="Deviation"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Premium Name" DataField="premiumcode" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Card Premium" DataField="cardpremium" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Contract Premium" DataField="dealpremium" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="UOM" DataField="Uom" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Volume Billed" DataField="volumebilled" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Volume disc." DataField="volumedisc" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="currency" HeaderText="Currency Type">
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Value From" DataField="valuefrom" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Value To" DataField="valueto" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="convertrate" HeaderText="Total Rate">
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Rate_code" HeaderText="Rate Code">
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="approved" HeaderText="Approved">
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="quantity" HeaderText="Quantity">
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="weight" HeaderText="Weight">
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="discounted" HeaderText="Disc. Applied">
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ContractCode" ReadOnly="True" Visible="False"  />
                        <asp:BoundColumn HeaderText="Deal No" ReadOnly="True" Visible="False" DataField="ContractCode" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="SIZEFROM" HeaderText="Size From"></asp:BoundColumn>
                        <asp:BoundColumn DataField="SIZETO" HeaderText="Size To"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DISCTYPE" HeaderText="Disc Type"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DISCPER" HeaderText="Disc Per"></asp:BoundColumn>
                        <asp:BoundColumn DataField="INSERTION" HeaderText="Insertion"></asp:BoundColumn>
                        <asp:BoundColumn DataField="REMARKS" HeaderText="Remarks"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DAYNAME" HeaderText="Day"></asp:BoundColumn>
                        <asp:BoundColumn DataField="COMMITION_ALLOW" HeaderText="COMMITION_ALLOW"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DEAL_START" HeaderText="DEAL_START"></asp:BoundColumn>
                    </Columns>
                </asp:datagrid> 
           </div>
          </div>
          <!--- for electrinics------>
           <div id="div_electronics">
           <table border="1" align="center"><tr><td>
           <table >  <tr valign="top"><td></td>
                                      <td valign="top"><asp:CheckBox ID="chkb2b" Text="B2B" runat="server" CssClass="TextField" /></td>
                                      <td valign="top"><asp:CheckBox ID="chkmultiad" Text="Multi Ad in Same Break" runat="server" CssClass="TextField" /></td>
                                      
                                      <td valign="top"><asp:CheckBox ID="chkseqno" Text="Sequence No. should be Allowable" runat="server" CssClass="TextField" />
                                     <asp:TextBox ID="txtseq" runat="server" onkeypress="return notchar2();" CssClass="TextField" style="width:20px" Enabled="false" ></asp:TextBox>
                                      </td>
                                      <td valign="top"><asp:CheckBox ID="chkpatricularad"  Text="After A Particular Ad" runat="server" CssClass="TextField" /></td>
                                      <td valign="top"><asp:DropDownList ID="drpindustry" runat="server" CssClass="dropdown"></asp:DropDownList></td>
                                      <td valign="top"><asp:ListBox ID="lstproduct" runat="server" CssClass="dropdown" SelectionMode="Multiple"></asp:ListBox>
                                      </td>
                                      </tr></table></td></tr></table>
        <table align="center" cellpadding="0" cellspacing="0">
         <tr>
               
                     <td  style="height: 21px" >
                    <asp:Label ID="lbllocation" runat="server" CssClass="TextField"></asp:Label>
                  
                    </td>
                <td>
                    <asp:DropDownList ID="drplocation" runat="server" CssClass="dropdown">
                    </asp:DropDownList>
                  
                    </td>
                     <td>
                    <asp:Label ID="lblchannel" runat="server" CssClass="TextField"></asp:Label>
                  
                    </td>
                <td>
                    <asp:DropDownList ID="drpchannel" runat="server" CssClass="dropdown">
                    </asp:DropDownList>
                  
                    </td>
                     <td >
                    <asp:Label ID="lblpaidbonus" runat="server" CssClass="TextField"></asp:Label>
                  
                    </td>
                <td style="height: 21px" >
                    <asp:DropDownList ID="drppaidbonus" runat="server" CssClass="dropdown">
                    <asp:ListItem Value="p" Text="Paid"></asp:ListItem>
                    <asp:ListItem Value="b" Text="Bonus"></asp:ListItem>
                    </asp:DropDownList>
                  
                    </td>
                    </tr>
                    <tr>
                     <td style="height: 21px" >
                
                    <asp:Label ID="volumeunit_elec" runat="server" CssClass="TextField"></asp:Label>
                   
                    </td>
                <td style="height: 21px" > 
                   
                <asp:DropDownList ID="drpuom_elec" runat="server" CssClass="dropdown" AutoPostBack="false">
                    </asp:DropDownList>
                    
                  
                    
                    
                    </td>
                     <td >
                    <asp:Label ID="lblprogtype" runat="server" CssClass="TextField"></asp:Label> 

                    </td>
                    <td >
                    <asp:DropDownList ID="drpprogramtype" runat="server" CssClass="dropdown"></asp:DropDownList>

                    </td>
                    <td >
                    <asp:Label ID="lblprogramcode" runat="server" CssClass="TextField"></asp:Label> 

                    </td>
                    <td >
                    <asp:TextBox ID="txtprogramcode" runat="server" CssClass="btext1"></asp:TextBox>

                    </td>
                    </tr>
            <tr>
             <td valign="top">
                    <asp:Label ID="lblbtb" runat="server" CssClass="TextField"></asp:Label> 

                    </td>
                    <td valign="top">
                    <asp:TextBox ID="txtbtb" runat="server" CssClass="btext1"></asp:TextBox>

                    </td>
         <td valign="top">
                    <asp:Label ID="lblros" runat="server" CssClass="TextField"></asp:Label> 

                    </td>
                    <td valign="top">
                    <asp:TextBox ID="txtros" runat="server" CssClass="btext1"></asp:TextBox>

                    </td>
											
											   <td valign="top" rowspan="2"> <asp:label id="lblday_elec" runat="server" Text="Day" CssClass="TextField"></asp:label></td>
                                        <td rowspan="2">
                                        <asp:ListBox ID="drpday_elec" runat="server" CssClass="dropdown" SelectionMode="Multiple" Enabled="False">
                                        <asp:ListItem Value="0" Text="Select Day"></asp:ListItem>
                                        <asp:ListItem Value="sun" Text="SUN"></asp:ListItem>
                                        <asp:ListItem Value="mon" Text="MON"></asp:ListItem>
                                        <asp:ListItem Value="tue" Text="TUE"></asp:ListItem>
                                        <asp:ListItem Value="wed" Text="WED"></asp:ListItem>
                                        <asp:ListItem Value="thu" Text="THU"></asp:ListItem>
                                        <asp:ListItem Value="fri" Text="FRI"></asp:ListItem>
                                        <asp:ListItem Value="sat" Text="SAT"></asp:ListItem>
                </asp:ListBox>
                                            </td>  
										</tr>
										<tr> <td > 
                <asp:Label ID="packagecode_elec" runat="server" CssClass="TextField"></asp:Label>
                   
                    </td>
                <td align="left">
                <asp:DropDownList ID="drppackagecode_elec" runat="server" CssClass="dropdown" AutoPostBack="false" >
                    </asp:DropDownList>
                  
                    </td>
                    <td >
                  
                <asp:Label ID="bookedfor_elec" runat="server" CssClass="TextField"></asp:Label>
                  
                    </td> <td colspan="3">
                <asp:TextBox ID="drpbooked_elec" runat="server" style="width:220px"  CssClass="TextField" TextMode="MultiLine" Enabled="False"></asp:TextBox>
                 
                </td>
                    </tr>
										<tr>
										 <td style="height: 21px" ><asp:label id="lblinsertion_elec" runat="server" Text="No. Of Insertion" CssClass="TextField"></asp:label></td>
                                            <td><asp:TextBox ID="txtinsertion_elec" runat="server" CssClass="btext1" onkeypress="return notchar2();" ></asp:TextBox></td>
                                             <td >
               <asp:Label ID="Volumefrom_elec" runat="server" CssClass="TextField"></asp:Label>
                    </td>
                <td > 
                <asp:TextBox ID="txtvalfrom_elec" onkeypress="return notchar2();" runat="server" CssClass="btext1" MaxLength="10"></asp:TextBox>
                   
                    </td>
                       <td >
                <asp:Label ID="Volumeto_elec" runat="server" CssClass="TextField"></asp:Label>
                   
                    </td>
                <td >
                <asp:TextBox ID="txtvalto_elec" onkeypress="return notchar2();" runat="server" CssClass="btext1" MaxLength="10"></asp:TextBox>
                 
                    </td>
               
             
            </tr>
            <tr>
                <td style="width: 144px; height: 21px;" >
                    <asp:Label ID="agencycategory_elec" runat="server" CssClass="TextField"></asp:Label>
                  
                    </td>
                <td style="height: 21px" >
                    <asp:DropDownList ID="drpadvcat_elec" runat="server" CssClass="dropdown">
                    </asp:DropDownList>
                  
                    </td>
                    <td>
                    <asp:Label ID="lbdisc_elec" runat="server" CssClass="TextField"></asp:Label></td>
                <td>
             
                        <asp:DropDownList ID="drpdisc_elec" runat="server" CssClass="dropdown">
                        <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                        <asp:ListItem Value="1" >Free</asp:ListItem>
                        <asp:ListItem Value="2" >Discounted</asp:ListItem>
                         <asp:ListItem Value="3" >Fixed Rate</asp:ListItem>
                        </asp:DropDownList>
                </td>
                <td> <asp:Label ID="lbldiscamt_elec" runat="server" Text="Discount Per." CssClass="TextField"></asp:Label>
                    </td>
                <td>
                    <asp:TextBox ID="txtdiscamount_elec" runat="server" CssClass="btext1" style="width:50px;text-align:right;" onkeypress="return notchar2();" Enabled="False"></asp:TextBox></td>

                </tr>
              
                <tr>  <td  >
                    <asp:Label ID="PremiumCode_elec" runat="server" CssClass="TextField"></asp:Label>
                 
                    </td>
                <td >
                    <asp:DropDownList ID="drppremium_elec" runat="server" CssClass="dropdown" >
                    </asp:DropDownList>
                   
                    </td>
                     <td> 
                    <asp:Label ID="CardPremium_elec" runat="server" CssClass="TextField"></asp:Label></td>
                <td >
                    <asp:TextBox ID="txtcardpremium_elec" onkeypress="return notchar2();" runat="server" CssClass="btext1" MaxLength="10"></asp:TextBox>
                 
                    </td>
                     <td>
                    <asp:Label ID="DealPremium_elec" runat="server" CssClass="TextField"></asp:Label></td>
                <td >
                  
                    <asp:TextBox ID="txtdealpremium_elec" onkeypress="return notchar2();" runat="server" CssClass="btext1" MaxLength="10"></asp:TextBox>
                  
                    </td>
                    </tr>
                    <tr>    <td>
                  
                    <asp:Label ID="DealRate_elec" runat="server" CssClass="TextField"></asp:Label>
                    
                    </td>
                <td>
                
                        <asp:TextBox ID="txtdealrate_elec" runat="server" CssClass="btext1" MaxLength="10" onkeypress="return notchar2();"></asp:TextBox>
                  
                </td>
                  <td >
               
                    <asp:Label ID="CardRate_elec" runat="server" CssClass="TextField"></asp:Label>
                 
                    </td>
                <td > 
              
                    <asp:TextBox ID="txtcardrate_elec" onkeypress="return notchar2();" runat="server" CssClass="btext1" MaxLength="5"></asp:TextBox>
                   
                    </td>
                      <td > 
                    <asp:Label ID="lbdeviation_elec" runat="server" CssClass="TextField"></asp:Label></td>
                <td > 
                  
                    <asp:TextBox ID="txtdeviation_elec" onkeypress="return notchar2();" runat="server" CssClass="btext1" MaxLength="5" Enabled="False"></asp:TextBox>
                  
                    </td> 
                 </tr>
                 <tr> <td >  <asp:Label ID="lblsizefrom_elec" runat="server" Text="Min Size" CssClass="TextField"></asp:Label>
                    </td>
                <td > 
                 <asp:TextBox ID="txtsizefrom_elec" onkeypress="return notchar2();" runat="server" CssClass="btext1" MaxLength="10"></asp:TextBox>
                    </td>
                    <td >  <asp:Label ID="lblsizeto_elec" runat="server" Text="Max Size" CssClass="TextField"></asp:Label>
                    </td>
                <td > 
                 <asp:TextBox ID="txtsizeto_elec" onkeypress="return notchar2();" runat="server" CssClass="btext1" MaxLength="10"></asp:TextBox>
                    </td>
                    <td >
                <asp:Label ID="lbcurr_elec" runat="server" CssClass="TextField"></asp:Label>
                    </td>
                <td >
                <asp:DropDownList ID="drpcurr_elec" runat="server" CssClass="dropdown" Enabled="False">
                </asp:DropDownList>
                
                    </td>
                    </tr>
                    <tr>  <td ><asp:label id="lbldealstart_elec" runat="server" Text="Deal Start" CssClass="TextField"></asp:label></td> 
                                                <td><asp:DropDownList ID="drpdealstrt_elec" runat="server" CssClass="dropdown">
                                                    <asp:ListItem Value="A">After Target Achived</asp:ListItem>
                                                    <asp:ListItem Value="B">From Begining</asp:ListItem></asp:DropDownList></td>
                                                      <td ><asp:label id="lblcommallow_elec" runat="server" Text="Commision Allow" CssClass="TextField"></asp:label></td>
                                                <td><asp:DropDownList ID="drpcommallow_elec" runat="server" CssClass="dropdown">
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N">No</asp:ListItem></asp:DropDownList></td>
                                                    <td  > 
                    <asp:Label ID="editionaldisc_elec" runat="server" CssClass="TextField"></asp:Label></td>
                <td > 
             <asp:DropDownList ID="drpratecode_elec" runat="server" CssClass="dropdown">
                    </asp:DropDownList>
                  
                    </td>
                                                    </tr>
            <tr><td ><asp:label id="lblincentive_elec" runat="server" CssClass="TextField"></asp:label></td>
                                            <td><asp:TextBox ID="txtincentive_elec" runat="server" CssClass="btext1" onkeypress="return notchar2();" ></asp:TextBox></td>
                  <td>
                    <asp:Label ID="lbtotal_elec" runat="server" CssClass="TextField"></asp:Label></td>
                <td>
             
                        <asp:TextBox ID="txttotal_elec" runat="server" CssClass="btext1" onkeypress="return notchar2();" Enabled="False"></asp:TextBox>
                
                </td>     
                <td><asp:Label ID="lbldisctype_elec" runat="server" Text="Discount Type" CssClass="TextField"></asp:Label>
                    </td>
                    <td>
                <asp:DropDownList ID="drpdisctype_elec" runat="server" CssClass="dropdown">
                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                <asp:ListItem Value="1" Text="Discount On Bill"></asp:ListItem>
                <asp:ListItem Value="2" Text="Discount through Credit Note"></asp:ListItem>
                    </asp:DropDownList>
                </td>                                       
                                            </tr>
                                            <tr>   <td>
                                                <asp:Label ID="lblvalidfrom" runat="server" CssClass="TextField"></asp:Label></td>
											<td style="width: 190px" >
												

                                               
                                               
                                                <asp:TextBox ID="txtfromdate" runat="server" CssClass="btext1" Enabled="False" AutoPostBack="True" ></asp:TextBox>
                                            
                                            <img src='Images/cal1.gif'  runat="server"  onclick='popUpCalendar(this, Form1.txtfromdate, "mm/dd/yyyy")' height="14" width="14" id="Img1"> 
                                            
                                            
                                            
                                                 
                                                </td>
                                                  <td>
                                                <asp:Label ID="lbltilldate" runat="server" CssClass="TextField"></asp:Label>
                                                 
                                                
                                                </td>
											<td>
											
                                                <asp:TextBox ID="txttilldate" runat="server" CssClass="btext1" Enabled="False"></asp:TextBox>
                                                <img src='Images/cal1.gif'  runat="server"  onclick='popUpCalendar(this, Form1.TextBox1, "mm/dd/yyyy")' height=14 width=14 id="Img2"> 
												
                                                
                                                
                                             
                                                
                                                
                                                
                                                </td>
                                                 <td>
                    <asp:Label ID="approved_elec" runat="server" CssClass="TextField"></asp:Label></td>
                <td>
              
                        <asp:CheckBox ID="ckbapproved_elec" runat="server" CssClass="TextField" />
                 
                </td>
                                                </tr>   
                                                  <tr>
                <td > 
                <asp:Label ID="lblconsumed" runat="server" CssClass="TextField"></asp:Label></td>
                <td >
                <asp:TextBox ID="txtconsumed" runat="server" CssClass="btext1" Enabled="false"></asp:TextBox>

                </td>
                                <td > 
                <asp:Label ID="lblbalance" runat="server" CssClass="TextField"></asp:Label></td>
                <td >
                <asp:TextBox ID="txtbalance" runat="server" CssClass="btext1" Enabled="false"></asp:TextBox>

                </td>
               
                
            </tr>                                                 
            <tr style="display:none;"> 
                   
                <td > 
              
                    <asp:Label ID="Volumedisc_elec" runat="server" CssClass="TextField"></asp:Label>
                  
                    </td>
                <td >
                    <asp:TextBox ID="txtvoldisc_elec" onkeypress="return notchar2();" runat="server" CssClass="btext1" MaxLength="10"></asp:TextBox>
                  
                    </td>
                    </tr>
            <tr  style="display:none;">
                 <td >
                <asp:Label ID="VolumeBilled_elec" runat="server" CssClass="TextField"></asp:Label> 
                  
                    </td>
                <td >
               <asp:TextBox ID="txtvolbilled_elec" onkeypress="return notchar2();" runat="server" CssClass="btext1" MaxLength="10"></asp:TextBox>
                 
                    </td>
                </tr>
         
            <tr style="display:none">
                
           
                <td> <asp:Label ID="lbquantity_elec" runat="server" CssClass="TextField"></asp:Label></td><td> 
                        <asp:TextBox ID="txtquantity_elec" runat="server" CssClass="btext1" MaxLength="5" onkeypress="return notchar();"></asp:TextBox>
                  
                    </td>
            </tr>
          
          
            <tr style="display:none">
               
              
               <td > 
                    <asp:Label ID="lbweight_elec" runat="server" CssClass="TextField"></asp:Label></td>
                <td >
                        <asp:TextBox ID="txtweight_elec" runat="server" CssClass="btext1" MaxLength="5" onkeypress="return notchar2();"></asp:TextBox>
                 
                    </td>
            </tr>
          
            <tr>
                <td >
                    <asp:label id="lblremarks_elec" runat="server" Text="Remarks" CssClass="TextField"></asp:label></td>
                <td colspan="3">
                   <asp:TextBox ID="txtremark_elec"  runat="server" CssClass="btext1" Enabled="False" MaxLength="1000" style="width:447px;"></asp:TextBox></td>
                <td>
                    </td>
                <td>
                    &nbsp;</td>
                <td>
                </td>
                <td >
                </td>
            </tr>
            <tr>
                <td style="height: 21px">
                </td>
                <td style="height: 21px">
                </td>
                <td style="height: 21px">
                </td>
                <td style="height: 21px">
                </td>
                <td style="height: 21px">
                </td>
                <td style="height: 21px">
                </td>
            </tr>
            <tr>
                <td style="display:none">
              
                    <asp:Label ID="publication_elec" runat="server" CssClass="TextField"></asp:Label>
                    
                </td>
                <td style="display:none">
             
                    <asp:DropDownList ID="drppublication_elec" runat="server" CssClass="dropdown" AutoPostBack="false" >
                    </asp:DropDownList>
                  
                </td>
                <td style="display:none">
             
                <asp:Label ID="suppliment_elec" runat="server" CssClass="TextField"></asp:Label>
                 
                </td>
                <td style="display:none">
                
                <asp:DropDownList ID="drpsuppliment_elec" runat="server" CssClass="dropdown">
                    </asp:DropDownList>
                   
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="display:none">
               
                <asp:Label ID="edition_elec" runat="server" CssClass="TextField"></asp:Label>
                   
                </td>
                <td style="display:none">
            
                <asp:DropDownList ID="drpedition_elec" runat="server" CssClass="dropdown" AutoPostBack="false" >
                    </asp:DropDownList>
                 
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="display:none">
                 
                            <asp:Label ID="CYOP_elec" runat="server" CssClass="TextField"></asp:Label>
                       
                </td>
                <td style="display:none">
                   
                            <asp:CheckBox ID="chbcyop_elec" runat="server" CssClass="TextField" />
                       
                </td>
                <td><input id="hiddenagency_elec" runat="server" type="hidden" /></td>
                <td><input id="hiddenclient_elec" runat="server" type="hidden" /></td>
                <td><input id="hiddenproduct_elec" runat="server" type="hidden" /></td>
                <td>
                </td>
            </tr>
            <tr>
                <td >
                    <input id="hiddendealcode_elec" runat="server" type="hidden" />
                    <input id="hiddenadtype_elec" runat="server" type="hidden" /></td>
                <td>
                    <input id="hiddencompcode_elec" runat="server" type="hidden" />
                    <input id="hiddenfromdate_elec" runat="server" type="hidden" /></td>
                <td><input id="hiddentodate_elec" runat="server" type="hidden" />
                    <input id="hiddenuserid_elec" runat="server" type="hidden" /></td>
                <td><input id="hiddenvalue_elec" runat="server" type="hidden" />
                    <input id="hiddensavemod_elec" runat="server" type="hidden" /></td>
                <td><input id="hiddenvolume_elec" runat="server" type="hidden" />
                    <input id="hiddendeal_elec" runat="server" type="hidden" /></td>
                <td align="right">
                    <asp:Button ID="btnselect_elec" runat="server" CssClass="button1" Text="Save"  /><asp:Button
                        ID="btnclear_elec" runat="server" CssClass="button1" Text="Clear"  />
                      
                        
                        </td>
            </tr>
            
        </table>
    
    
    
    
       <div id="firgri_elec" runat="server" style="OVERFLOW: auto; WIDTH: 960px; HEIGHT: 176px">
   
                <asp:datagrid  ID="GridView1_elec" runat="server" AutoGenerateColumns="False" OnItemDataBound="GridView1_ItemDataBound" AllowSorting="True" CssClass="dtGrid" OnSortCommand="GridView1_SortCommand"    >
                <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
                <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3" />
                    <Columns>
                        <asp:TemplateColumn HeaderText="New"></asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Modify"></asp:TemplateColumn>
                        <asp:BoundColumn HeaderText="Ad. Category" DataField="Advcategory" SortExpression="Advcategory" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Package Name" DataField="packagecode" SortExpression="packagecode" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Package Description" DataField="Bookedfor" SortExpression="Bookedfor" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Publication" DataField="publication" SortExpression="publication" Visible="False" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Suppliment" DataField="suppliment" SortExpression="suppliment" Visible="False" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Edition" DataField="edition" SortExpression="edition" Visible="False" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Cyop" HeaderText="CYOP" SortExpression="Cyop" Visible="False"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Hue" DataField="color" SortExpression="color" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Card Rate" DataField="cardrate" SortExpression="cardrate" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Contract  Rate" DataField="Dealarte" SortExpression="Dealarte" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="deviation" HeaderText="Deviation" SortExpression="deviation">
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Premium Name" DataField="premiumcode" SortExpression="premiumcode" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Card Premium" DataField="cardpremium" SortExpression="cardpremium" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Contract Premium" DataField="dealpremium" SortExpression="dealpremium" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="UOM" DataField="Uom" SortExpression="Uom" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Volume Billed" DataField="volumebilled" SortExpression="volumebilled" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Volume disc." DataField="volumedisc" SortExpression="volumedisc" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="currency" HeaderText="Currency Type" SortExpression="currency">
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Value From" DataField="valuefrom" SortExpression="valuefrom" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Value To" DataField="valueto" SortExpression="valueto" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="convertrate" HeaderText="Total Rate" SortExpression="convertrate">
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Rate_code" HeaderText="Rate Code" SortExpression="Rate_code">
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="approved" HeaderText="Approved" SortExpression="approved">
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="quantity" HeaderText="Quantity" SortExpression="quantity">
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="weight" HeaderText="Weight" SortExpression="weight">
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="discounted" HeaderText="Disc. Applied" SortExpression="discounted">
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ContractCode" ReadOnly="True" Visible="False"  />
                        <asp:BoundColumn HeaderText="Deal No" ReadOnly="True" Visible="False" DataField="ContractCode" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="SIZEFROM" HeaderText="Size From"></asp:BoundColumn>
                        <asp:BoundColumn DataField="SIZETO" HeaderText="Size To"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DISCTYPE" HeaderText="Disc Type"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DISCPER" HeaderText="Disc Per"></asp:BoundColumn>
                        <asp:BoundColumn DataField="INSERTION" HeaderText="Insertion"></asp:BoundColumn>
                        <asp:BoundColumn DataField="REMARKS" HeaderText="Remarks"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DAYNAME" HeaderText="Day"></asp:BoundColumn>
                         <asp:BoundColumn DataField="COMMITION_ALLOW" HeaderText="COMMITION_ALLOW"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DEAL_START" HeaderText="DEAL_START"></asp:BoundColumn>
                    </Columns>
                </asp:datagrid> 
          </div>
            <!--/*****************8*****************-->
            
            <div id="secgri_elec" runat="server"  style="OVERFLOW: auto; WIDTH: 955px; HEIGHT: 176px">
     
                <asp:datagrid  ID="Datagrid1_elec" runat="server" AutoGenerateColumns="False" OnItemDataBound="Datagrid1_ItemDataBound" AllowSorting="True" CssClass="dtGrid" OnSortCommand="GridView1_SortCommand"    >
                <SelectedItemStyle Font-Size="XX-Small" BackColor="#046791"></SelectedItemStyle>
                <HeaderStyle HorizontalAlign="Center" Height="20px" ForeColor="White" CssClass="dtGridHd12" BackColor="#7DAAE3" />
                    <Columns>
                        <asp:BoundColumn HeaderText="Ad. Category" DataField="Advcategory" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Package Name" DataField="packagecode" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Package Description" DataField="Bookedfor" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Publication" DataField="publication" Visible="False" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Suppliment" DataField="suppliment" Visible="False" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Edition" DataField="edition" Visible="False" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Cyop" HeaderText="CYOP" SortExpression="Cyop" Visible="False"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Hue" DataField="color" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Card Rate" DataField="cardrate" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Contract  Rate" DataField="Dealarte" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="deviation" HeaderText="Deviation"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Premium Name" DataField="premiumcode" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Card Premium" DataField="cardpremium" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Contract Premium" DataField="dealpremium" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="UOM" DataField="Uom" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Volume Billed" DataField="volumebilled" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Volume disc." DataField="volumedisc" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="currency" HeaderText="Currency Type">
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Value From" DataField="valuefrom" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Value To" DataField="valueto" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="convertrate" HeaderText="Total Rate">
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Rate_code" HeaderText="Rate Code">
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="approved" HeaderText="Approved">
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="quantity" HeaderText="Quantity">
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="weight" HeaderText="Weight">
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="discounted" HeaderText="Disc. Applied">
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="ContractCode" ReadOnly="True" Visible="False"  />
                        <asp:BoundColumn HeaderText="Deal No" ReadOnly="True" Visible="False" DataField="ContractCode" >
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="SIZEFROM" HeaderText="Size From"></asp:BoundColumn>
                        <asp:BoundColumn DataField="SIZETO" HeaderText="Size To"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DISCTYPE" HeaderText="Disc Type"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DISCPER" HeaderText="Disc Per"></asp:BoundColumn>
                        <asp:BoundColumn DataField="INSERTION" HeaderText="Insertion"></asp:BoundColumn>
                        <asp:BoundColumn DataField="REMARKS" HeaderText="Remarks"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DAYNAME" HeaderText="Day"></asp:BoundColumn>
                        <asp:BoundColumn DataField="COMMITION_ALLOW" HeaderText="COMMITION_ALLOW"></asp:BoundColumn>
                        <asp:BoundColumn DataField="DEAL_START" HeaderText="DEAL_START"></asp:BoundColumn>
                    </Columns>
                </asp:datagrid> 
           </div>
          </div>
          </td></tr></table>  
            <table  width="920px"><tr><td  style="height: 97px" ><input id="hiddencurrency" runat="server" type="hidden" />
                <input id="hidecurr" runat="server" type="hidden" />
                <input id="hideopen" runat="server" type="hidden" />
                <input id="hiddenofpop" runat="server" type="hidden" />
                 <input id="hiddendateformat" runat="server" type="hidden" />
                 <input id="hiddenpackagedesc" runat="server" type="hidden" />
                 <input id="hiddencardrate" runat="server" type="hidden" />
                 <input id="hiddendeviation" runat="server" type="hidden" />
                 <input id="hiddencardpremium" runat="server" type="hidden" />
                 <input id="hiddencontractpremium" runat="server" type="hidden" />
                <input id="hiddencyop" runat="server" type="hidden" /></td><td align="right" width="853px"><asp:Button ID="btnclose" runat="server" CssClass="button1" Text="Close" /></td><td  align="right" style="height: 97px">
          
                <asp:Button ID="btnclick" runat="server" CssClass="button1" 
                    Text="Delete" OnClick="btnclick_Click" Enabled="False" />
           
                </td></tr></table>
        
       
            
    </form>
</body>
</html>
