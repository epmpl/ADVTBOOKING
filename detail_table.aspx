<%@ Page Language="C#" AutoEventWireup="true" CodeFile="detail_table.aspx.cs" Inherits="detail_table" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Detail</title>
  <style type="text/css">
        .style2
        {
            width: 207px;
        }
        .style3
        {
            font-family : Arial;
            font-size : 12px;
            font-weight : bolder;
            color : Black;
            width: 200px;
        }
        
         .style355
        {
            font-family : Arial;
            font-size : 12px;
            font-weight : bolder;
            color : Black;
        }
        .style4
        {
            /*height:0px; 
	width: 300px; */
	    font-size: 14px;
            font-weight: bold;
            font-family: Arial;
            Color: #000000;
            width: 552px;
        }
        .style5
        {
            font-family : Arial;
            font-size : 12px;
            font-weight : bolder;
            color : Black;
            width: 552px;
        }
        .style6
        {
            font-family : Arial;
            font-size : 12px;
            font-weight : bolder;
            color : Black;
            width: 949px;
        }
    </style>

    <script language="javascript" type="text/javascript" src="javascript/detail_table.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table cellpadding="0" cellspacing="0" width="100%" border="0">
    <tr>
       <td width="70%"></td>
    </tr>
    </table>
    
    <table cellpadding="0" cellspacing="0" border="0" style="margin-top:10px; margin-bottom:2px;" width="100%">
    <tr>
      <%-- <td width="10%"><asp:ImageButton ID="btnprint"  OnClick="btnprint_Click" runat="server" ImageUrl="images/print1.jpg" /></td>--%>
       <td width="80%" align="center"><asp:Label ID="lblname" align="center" runat="server" CssClass="heading"></asp:Label></td>
       <td width="10%"></td>
    </tr>

    </table>
        
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr>
       <td align="center"  style="font-size:medium; "  width="100%"
            class="style355"><asp:Label ID="lblunit" runat="server"></asp:Label></td><td></td>
    </tr>
    <tr>
       <td align="center"  style="font-size:medium; "  width="100%"
            class="style355"><asp:Label ID="lblreportname" runat="server"></asp:Label></td><td></td>
    </tr>
   <%-- <tr height="15px">
           <td colspan="3"></td>
    </tr>--%>
    </table>
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
    <tr>
       <td width="50%" align="right"  class="style355" style="display:none"><asp:Label ID="lblcreationfrmdate" runat="server" Width="30%"></asp:Label>:&nbsp;<asp:Label ID="lbllastusedfrmdt" runat="server"></asp:Label>&nbsp;&nbsp;</td>
       <td  width="50%"  class="style5" align="left" style="display:none"><asp:Label ID="lblcreationtodate" runat="server" ></asp:Label>:&nbsp;<asp:Label ID="lbllastusedtodt" runat="server"></asp:Label></td>
    </tr>
    </table>
    
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
               <td align="right"  class="style6" style="display:none"> <asp:Label ID="lblrundate" runat="server" Width="35%" Height="16px"></asp:Label>:&nbsp;<asp:Label ID="lblrundt" runat="server"></asp:Label></td>
    </tr>
          
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
       <td width="100%" id="report" runat="server" valign="top"></td>
    </tr>
     <tr>
                                        <td align=center colspan=2>
                                            <div runat="server" id="wAITING" style="display:none">
                                                <img src="images/loading1.gif" />
                                            </div>
                                        </td>
                                     </tr>
    </table>
    </table>

        <input type="hidden" id="hdndateformat" runat="server" />
        <input type="hidden" id="hdncompcode" runat="server" />
        <input id="hdncomp_name" type="hidden" name="hiddencompcode" runat="server" />
        <input id="hiddenuserid" type="hidden" name="hiddenuserid" runat="server" />
        <input id="hiddenuser" type="hidden" size="1" name="hiddenuser" runat="server" />
        <input id="hiddenmodulename" type="hidden" size="1" name="hiddenmodulename" runat="server" />
        <input id="hiddenDateFormat" type="hidden" size="1" name="Hidden2" runat="server"/>
        <input id="hiddenusername" type="hidden" size="1" name="Hidden1" runat="server" />
        <input id="hiddenRoleId" type="hidden" size="1" name="hiddenmoduleno" runat="server" />
        <input id="hiddendivision" type="hidden" size="1" name="hiddendivision" runat="server" />


    </form>
</body>
</html>
