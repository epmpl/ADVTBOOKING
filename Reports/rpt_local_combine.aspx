<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rpt_local_combine.aspx.cs" Inherits="Reports_rpt_local_combine" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="css/main.css" type="text/css" rel="stylesheet" />
    <link href="css/booking.css" type="text/css" rel="stylesheet" />
    <link href="css/report.css" type="text/css" rel="stylesheet" />

    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <script type="text/javascript" language="javascript" src="javascript/datevalidation.js"></script>
    <script type="text/javascript" language="javascript" src="javascript/popupcalender.js"></script>
    <script type="text/javascript" language="javascript" src="javascript/rpt_local_combine.js"></script>
    <script type="text/javascript" language="javascript" src="javascript/entertotab.js"></script>
    <%--<script type="text/javascript" language="javascript" src="javascript/rept.js"></script>--%>
    <style type="text/css">
        .style1
        {
            FONT-WEIGHT: bold;
            FONT-SIZE: xx-large;
            COLOR: #ffffff;
        }

        .style2
        {
            COLOR: #ffffff;
        }

        .style4
        {
            FONT-WEIGHT: normal;
            FONT-SIZE: 14pt;
            COLOR: #d85414;
            FONT-FAMILY: Verdana;
        }

        .style6
        {
            FONT-SIZE: x-small;
        }

        .style7
        {
            FONT-WEIGHT: bold;
            COLOR: #6666ff;
        }

        .auto-style1
        {
            height: 24px;
        }
    </style>
</head>
    <body>
    <form id="form1" runat="server">
        <div>
            <table width="1005" border="0" cellspacing="0" cellpadding="0" align="center" style="WIDTH: 1005px; HEIGHT: 358px">
                <tr>
                    <td width="100%" bordercolor="#1">
                        <img src="images/img_02A.jpg" width="1004" border="0" />
                        <%-- <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>--%>
                    </td>
                </tr>
                <tr>
                    <td id="td2" onclick="javascript:return logoutpage();" width="100%" bordercolor="#1" style="background-image: url('images/top.jpg'); font-family: Trebuchet MS; font-size: 13px; color: #CC0000; cursor: hand;" align="right">Logout</td>
                </tr>
                <tr>
                    <td style="height: 505px">
                        <table width="985" border="0" cellspacing="0" cellpadding="0" style="WIDTH: 985px; HEIGHT: 486px">
                            <tr>
								<!--------left bar start--------->
								<td width="200" style="WIDTH: 200px"><img src="images/leftbar.jpg" style="WIDTH: 193px; HEIGHT: 483px" height="483" width="193" /></td>
								<!--------left bar end--------->
                               
                                
                               
                                <!--------middle start--------->
                                <td valign="top" style="width: 78%">

                                    <table cellpadding="0" cellspacing="0" width="790" style="WIDTH: 790px; HEIGHT: 488px"
                                        bordercolordark="#000000" border="1">
                                        <tr>
                                            <td align="center">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="heading" runat="server" CssClass="heading" Text="Local/Combine Reports"></asp:Label></td>
                                                    </tr>
                                                </table>
                                                <br />

                                                <table width="0" border="0" cellspacing="0" cellpadding="0">
                                                  <tr >
            <td align="left">
                <asp:Label ID="lblfromdate" runat="server" CssClass="TextField"></asp:Label></td>
            <td align="left">
                <asp:TextBox  id="txtfromdate" runat="server" CssClass="cls_schname" MaxLength="10" Height="16px" Width="100px"></asp:TextBox>
            <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txtfromdate,"dd/mm/yyyy")' height="14" width="14"/></td>
           <td align="left">
               <asp:Label ID="lbltodate" runat="server" CssClass="TextField"></asp:Label></td>
            <td align="left">
                <asp:TextBox  id="txttodate" runat="server" CssClass="cls_schname" MaxLength="10" Height="16px" Width="100px">
                </asp:TextBox>
            <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txttodate,"dd/mm/yyyy")' height="14" width="14"/></td>
            </tr>
                                                    <tr>
                                                       <td align="left" style="width: 106px"><asp:Label ID="lblpub" runat="server" CssClass="TextField" ></asp:Label></td>
           <td  align="left">
            <asp:DropDownList  ID="dppub1"  runat="server"  CssClass="dropdown" ></asp:DropDownList>
                 </td>
          </tr>
                                                    </tr>
                                                      <tr>

          <td align="left"><asp:Label id="lblbranch" runat="server" CssClass="TextField" ></asp:Label></td>
														<td align="left">
                                                                
                                                                     <asp:DropDownList id="dpd_branch" runat="server" CssClass="dropdown"></asp:DropDownList>
                                                             
                                                        </td>
                                                           </tr>
                                           <tr>
              <td align="left" style="width: 106px"><asp:Label ID="lblreporttype" runat="server" CssClass="TextField" ></asp:Label></td>
             <td  align="left"><asp:DropDownList runat="server" ID="drprprttype" CssClass="dropdown" >
      
            </asp:DropDownList></td>
        </tr>
                                           <tr>
              <td align="left" style="width: 106px"><asp:Label ID="lblratetype" runat="server" CssClass="TextField" ></asp:Label></td>
             <td  align="left"><asp:DropDownList runat="server" ID="drpratetype" CssClass="dropdown" >
      
            </asp:DropDownList></td>
        </tr>

                                        <tr>
              <td align="left" style="width: 106px"><asp:Label ID="lbldest" runat="server" CssClass="TextField" ></asp:Label></td>
             <td  align="left"><asp:DropDownList runat="server" ID="drpdest" CssClass="dropdown" >
      
            </asp:DropDownList></td>
        </tr>
                                  
                                  
        </table>

                                      <table>

              <tr style ="height:40px">
      <td colspan ="2" align ="center" >
          <asp:Button runat ="server" ID="btnsubmit" Text="Report" Width="56px" Height="26px" />
          <asp:Button ID="btncancel" runat="server" Text="Clear" Width="56px" Height="26px"  />
          <asp:Button ID="btnexit" runat="server" Text="Exit" Width="56px" Height="26px" />

      </td>
      </tr>
</table>
                                      <input type="hidden" runat="server" id="hdncom_name" />
    <input type="hidden" runat="server" id="hdndateformat" />
    <input type="hidden" runat="server" id="hdncomp_code" />
    <input type="hidden" runat="server" id="hdnuserid" />
    <input type="hidden" runat="server" id="hiddenconnection" />
    <input type="hidden" runat="server" id="hdnpublication" />
    <input type="hidden" runat="server" id="hiddendateformat" />
         
    
   
    </form>
</body>
</html>
