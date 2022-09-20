<%@ Page Language="C#" AutoEventWireup="true" CodeFile="contractchildprint.aspx.cs" Inherits="contractchildprint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="css/main.css" type="text/css" rel="stylesheet"/>
<script type="text/javascript" src="javascript/popupcalender.js"></script>
<script type="text/javascript" src="javascript/contractchildprint.js"></script>
    <title>Print Detail</title>
</head>
<body  style="background-color:#f3f6fd;"  onload="javascript:return execute();" onkeydown="javascript:return tabvalue(event);"  >
    <form id="form1" runat="server">
   <div id="divcommon" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1; " >
            <table cellpadding="0" cellspacing="0" >
                <tr>
                    <td>
                        <asp:ListBox ID="lstcommon" Width="170px" Height="80px" runat="server" CssClass="btextlist">
                        </asp:ListBox></td>
                </tr>
            </table>
        </div>
        
        <div id="div1" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1; " >
            <table cellpadding="0" cellspacing="0" >
                <tr>
                    <td>
                        <asp:ListBox ID="lstsubcat" Width="170px" Height="80px" runat="server" CssClass="btextlist">
                        </asp:ListBox></td>
                </tr>
            </table>
        </div>
        <div>
        <table  cellpadding="0" cellspacing="0" style="margin-left:10px;margin-top:10px">
        <tr>
        <td>
        <asp:Label ID="lbadtype" runat="server"  CssClass="TextField"></asp:Label>
        </td>
        <td>
        <asp:TextBox ID="txtadtype" runat="server" CssClass="btext1"></asp:TextBox>
        </td>
         <td>
        <asp:Label ID="lbhue" runat="server" style="margin-left:10px;" CssClass="TextField"></asp:Label>
        </td>
        <td>
        <asp:TextBox ID="txthue" runat="server" CssClass="btext1"></asp:TextBox>
        </td>
         <td>
        <asp:Label ID="lbumo" runat="server"  CssClass="TextField"></asp:Label>
        </td>
        <td>
        <asp:TextBox ID="txtumo" runat="server" CssClass="btext1"></asp:TextBox>
        </td>
         <td  style="margin-left:5px;">
        <asp:Label ID="lbctegory" runat="server"  CssClass="TextField"></asp:Label>
        </td>
        <td>
        <asp:TextBox ID="txtcategory" runat="server" CssClass="btext1"></asp:TextBox>
        </td>
         <td  style="margin-left:5px;">
        <asp:Label ID="lblsubcat" runat="server"  CssClass="TextField">AD.Sub.Cat.</asp:Label>
        </td>
        <td>
        <asp:TextBox ID="txtadsubcat" runat="server" CssClass="btext1"></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td >
         <asp:Label ID="lbpackage" runat="server"  CssClass="TextField"></asp:Label>
        </td>
        <td colspan="3" rowspan="1"  style=" margin-top:10px;">
        <asp:ListBox ID="listpackage" runat="server" CssClass="listbox" Height="61px" 
                Width="388px"></asp:ListBox>
        </td>
         <td valign="top" style="margin-left:5px;">
        <asp:Label ID="lbcurrency" runat="server"  CssClass="TextField"></asp:Label>
        </td>
        <td valign="top">
        <asp:TextBox ID="txtcurrency" runat="server" CssClass="btext1"></asp:TextBox>
        </td>
         <td valign="top" style="margin-left:5px;">
        <asp:Label ID="lbstatus" runat="server"  CssClass="TextField"></asp:Label>
        </td>
        <td valign="top">
        <asp:TextBox ID="txtstatus" runat="server" CssClass="btext1"></asp:TextBox>
        </td>
        </tr>
        <tr><td colspan="10" ><hr style="margin-right:25px; color:#7DAAE5; " /></td></tr>
      <tr>
      <td>
        <asp:Label ID="lbpremium" runat="server"  CssClass="TextField"></asp:Label>
        </td>
        <td>
        <asp:TextBox ID="txtpremium" runat="server" CssClass="btext1"></asp:TextBox>
        </td>
              <td>
        <asp:Label ID="lbcardprem" runat="server"  CssClass="TextField"></asp:Label>
        </td>
        <td>
        <asp:TextBox ID="txtcardprem" runat="server" CssClass="btext1" Enabled="false"></asp:TextBox>
        </td>
              <td>
        <asp:Label ID="lbcontractprem" runat="server"  CssClass="TextField"></asp:Label>
        </td>
        <td>
        <asp:TextBox ID="txtcontractperm" runat="server" CssClass="btext1"></asp:TextBox>
        </td>
          <td style="margin-left:5px;">
        <asp:Label ID="lbcomallow" runat="server"  CssClass="TextField"></asp:Label>
        </td>
        <td>
        <asp:TextBox ID="txtcomallow" runat="server" CssClass="btext1"></asp:TextBox>
        </td>
        </tr>
        <tr>
              <td>
        <asp:Label ID="lbpositionpremium" runat="server"  CssClass="TextField"></asp:Label>
        </td>
        <td>
        <asp:TextBox ID="txtpositiomprem" runat="server" CssClass="btext1"></asp:TextBox>
        </td>
        
              <td>
        <asp:Label ID="lbcardposprem" runat="server"  CssClass="TextField"></asp:Label>
        </td>
        <td>
        <asp:TextBox ID="txtcardpositionprem" runat="server" CssClass="btext1" Enabled="false"></asp:TextBox>
        </td>
        
              <td>
        <asp:Label ID="lbcontposprem" runat="server"  CssClass="TextField"></asp:Label>
        </td>
        <td>
        <asp:TextBox ID="txtcontarctpositionprem" runat="server" CssClass="btext1"></asp:TextBox>
        </td>
            <td style="margin-left:5px;">
        <asp:Label ID="lbratecode" runat="server"  CssClass="TextField"></asp:Label>
        </td>
        <td >
        <asp:TextBox ID="txtratecode" runat="server" CssClass="btext1"></asp:TextBox>
        </td>
        </tr>
        <tr>
              <td>
        <asp:Label ID="lbcontractrate" runat="server"  CssClass="TextField"></asp:Label>
        </td>
        <td>
        <asp:TextBox ID="txtcontractrate" runat="server" CssClass="btext1"></asp:TextBox>
        </td>
        
              <td>
        <asp:Label ID="lbcardrate" runat="server"  CssClass="TextField"></asp:Label>
        </td>
        <td>
        <asp:TextBox ID="txtcardrate" runat="server" CssClass="btext1" Enabled="false"></asp:TextBox>
        </td>
        
              <td>
        <asp:Label ID="lbdeviation" runat="server"  CssClass="TextField"></asp:Label>
        </td>
        <td>
        <asp:TextBox ID="txtdeviation" runat="server" CssClass="btext1"  Enabled="false"></asp:TextBox>
        </td>
         <td style="margin-left:5px;">
        <asp:Label ID="lbdealstart" runat="server"  CssClass="TextField"></asp:Label>
        </td>
        <td>
        <asp:TextBox ID="txtdealstart" runat="server" CssClass="btext1"></asp:TextBox>
        </td>
        </tr>
        <tr>
        
              <td>
        <asp:Label ID="lbcontarctamount" runat="server"  CssClass="TextField"></asp:Label>
        </td>
        <td>
        <asp:TextBox ID="txtcontractamount" runat="server" CssClass="btext1"></asp:TextBox>
        </td>
          <td>
        <asp:Label ID="lbdisctype" runat="server"  CssClass="TextField"></asp:Label>
        </td>
        <td>
        <asp:TextBox ID="txtdisctype" runat="server" CssClass="btext1"></asp:TextBox>
        </td>
        
        <td>
        <asp:Label ID="lbdiscper" runat="server"  CssClass="TextField"></asp:Label>
        </td>
        <td>
        <asp:TextBox ID="txtdiscper" runat="server" CssClass="btext1"></asp:TextBox>
        </td>
        
        <td style="margin-left:5px;">
        <asp:Label ID="lbdiscon" runat="server"  CssClass="TextField"></asp:Label>
        </td>
        <td>
        <asp:TextBox ID="txtdiscon" runat="server" CssClass="btext1"></asp:TextBox>
        </td>
        </tr>
          <tr><td colspan="10" ><hr style="margin-right:25px; color:#7DAAE5; " /></td></tr>
       <%--   <tr>
        
          </tr>--%>
          <tr>
          <td>
        <asp:Label ID="lbminsize" runat="server"  CssClass="TextField"></asp:Label>
        </td>
        <td>
        <asp:TextBox ID="txtminsize" runat="server" CssClass="btext1"></asp:TextBox>
        </td>
        
        <td>
        <asp:Label ID="lbmaxsize" runat="server"  CssClass="TextField"></asp:Label>
        </td>
        <td>
        <asp:TextBox ID="txtmaxsize" runat="server" CssClass="btext1"></asp:TextBox>
        </td>
        
        <td>
        <asp:Label ID="lbvaluefrom" runat="server"  CssClass="TextField"></asp:Label>
        </td>
        <td>
        <asp:TextBox ID="txtvaluefrom" runat="server" CssClass="btext1"></asp:TextBox>
        </td>
        <td style="margin-left:5px;">
        <asp:Label ID="lbvalueto" runat="server"  CssClass="TextField"></asp:Label>
        </td>
        <td>
        <asp:TextBox ID="txtvalueto" runat="server" CssClass="btext1"></asp:TextBox>
        </td>
        
          </tr>
          <tr>
          <td>
        <asp:Label ID="lbday" runat="server"  CssClass="TextField"></asp:Label>
        </td>
        <td>
        <asp:TextBox ID="txtday" runat="server" CssClass="btext1"></asp:TextBox>
        </td>
        
        <td>
        <asp:Label ID="lbinsertion" runat="server"  CssClass="TextField"></asp:Label>
        </td>
        <td>
        <asp:TextBox ID="txtinsertion" runat="server" CssClass="btext1"></asp:TextBox>
        </td>
        <td>
        <asp:Label ID="lbltoinsert" runat="server"  CssClass="TextField"></asp:Label>
        </td>
        <td >
        <asp:TextBox ID="txtinsert" runat="server" CssClass="btext1"></asp:TextBox>
        </td>

        
        <td style="margin-left:5px;">
        <asp:Label ID="lbincentive" runat="server"  CssClass="TextField"></asp:Label>
        </td>
        <td>
        <asp:TextBox ID="txtincentive" runat="server" CssClass="btext1"></asp:TextBox>
        </td>
      
        
        
       
          </tr>
          <tr>
                     <td>
        <asp:Label ID="lbtotalrate" runat="server"  CssClass="TextField"></asp:Label>
        </td>
        <td>
        <asp:TextBox ID="txttotalrate" runat="server" CssClass="btext1"></asp:TextBox>
        </td>
          
          
        <td>
        <asp:Label ID="lblbarter" runat="server"  CssClass="TextField"></asp:Label>
        </td>
        <td colspan="4">
        <asp:TextBox ID="txtbarter" runat="server" CssClass="btext1"></asp:TextBox>
        </td>
          </tr>
          <tr><td colspan="10" ><hr style="margin-right:20px; color:#7DAAE5; " /></td></tr>
        <%--  <tr>
      
     
          </tr>--%>
          <tr>
           <td>
        <asp:Label ID="lbremarks" runat="server"  CssClass="TextField"></asp:Label>
        </td>
        <td>
        <asp:TextBox ID="txtremarks" runat="server" TextMode="MultiLine" MaxLength="100" CssClass="btextextrabig"></asp:TextBox>
        </td>
        
        
          </tr>
          <tr><td style="margin-left:5px;"colspan="10" align="right"><input ID="btnOk" type="button" style="margin-right:18px" class="button1" runat="server" value="Ok" /></td></tr>
        </table></div>
            <input type="hidden" id="hiddencompcode" runat="server" />
    <input type="hidden" id="hiddenuserid" runat="server" />
    <input type="hidden" id="hiddendateformat" runat="server" />
       <input type="hidden" id="hiddenadtype" runat="server" />
         <input type="hidden" id="hiddenprem" runat="server" />
               <input type="hidden" id="hiddenhue" runat="server" />
         <input type="hidden" id="hiddeumo" runat="server" />
               <input type="hidden" id="hiddencategory" runat="server" />
         <input type="hidden" id="hiddencurrency" runat="server" />
               <input type="hidden" id="hiddenstatus" runat="server" />
         <input type="hidden" id="hiddenposiprem" runat="server" />
               <input type="hidden" id="hiddendisctype" runat="server" />
         <input type="hidden" id="hiddendiscon" runat="server" />
               <input type="hidden" id="hiddenday" runat="server" />
         <input type="hidden" id="hiddencommallow" runat="server" />
               <input type="hidden" id="hiddendealstart" runat="server" />
         <input type="hidden" id="hiddenratecode" runat="server" />
              <input type="hidden" id="hiddenpackagecode" runat="server" />
              <input type="hidden" id="hiddenvalidfrom" runat="server" />
               <input type="hidden" id="hiddenvalidto" runat="server" />
               <input type="hidden" id="hiddencenter" runat="server" />
               <input type="hidden" id="hidagency" runat="server" />
               <input type="hidden" id="hdncltcod" runat="server" />
               <input type="hidden" id="hdnagency" runat="server" />
               <input type="hidden" id="hdnbarter" runat="server" />
               <input type="hidden" id="hdnadsubcat" runat="server" />
    </form>
</body>
</html>
