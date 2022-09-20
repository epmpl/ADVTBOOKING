<%@ Page Language="C#" AutoEventWireup="true" CodeFile="noissuedate.aspx.cs" Inherits="noissuedate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/tr/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Display Ad. Booking & Sheduling No Issue Date</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1" />
    <meta name="CODE_LANGUAGE" content="C#" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <link href="css/main.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" language="javascript" src="javascript/NoIssueMaster.js"></script>

    <script type="text/javascript" language="javascript" src="javascript/popupcalender.js"></script>

    <script language="javascript" type="text/javascript" src="javascript/datevalidation.js"></script>

    <script language="javascript" type="text/javascript" src="javascript/Validations.js"></script>

    <%--	<script type="text/javascript"  language="javascript" src="javascript/entertotab.js"></script>--%>

    <script type="text/javascript" language="javascript">
	function dateenter(event)
{
var browser=navigator.appName;
if(browser!="Microsoft Internet Explorer")
 {
    if ((event.which>=48 && event.which<=57)||(event.which==47)||(event.which==11) ||(event.which==8))
     {

       return true;
     }
    else
     {
       return false;
     }
 }
 else
 {
   if ((event.keyCode>=48 && event.keyCode<=57)||(event.keyCode==47)||(event.keyCode==11))
   {

       return true;
   }
   else
   {
       return false;
   }
  }
}

function tabvalue (event,id)
{
 var browser=navigator.appName;
 if(browser!="Microsoft Internet Explorer")
 {
        if(event.which==13)
        {
        if(document.activeElement.id==id)
        {
            if(document.getElementById('btnsubmit').disabled==false)
            {
                document.getElementById('btnsubmit').focus();
            }
        return;

        }
        else if(document.activeElement.type=="button" || document.activeElement.type=="submit")
        {
            event.which=13;
            return event.which;

        }
        else
        {
           event.which=9;
          return event.which;
        }
        }
 }       
else
{
     if(event.keyCode==13)
        {
            if(document.activeElement.id==id)
            {
                if(document.getElementById('btnsubmit').disabled==false)
                {
                  document.getElementById('btnsubmit').focus();
                }
            return;

            }
            else if(document.activeElement.type=="button" || document.activeElement.type=="submit")
            {
                event.keyCode=13;
                return event.keyCode;

            }
            else
            {
                 event.keyCode=9;
                 return event.keyCode;
            }
        }
        
        if(event.keyCode==120)
        {
           var formname=document.URLUnencoded.substring(document.URLUnencoded.lastIndexOf("/")+1,document.URLUnencoded.lastIndexOf("."));
           window.open("Help.aspx?formname="+formname);
          
        }
}

}

    
    </script>

</head>
<body id="mybody" onload="javascript:return loadXML('xml/errorMessage.xml');" onkeydown="javascript:return tabvalue(event);"
    onkeypress="eventcalling(event);">
    <form id="Form1" method="post" runat="server">
    <table id="Table2" style="z-index: 100; left: 48px; position: absolute; top: 56px"
        cellspacing="0" cellpadding="0" width="560" border="1">
        <tr>
            <%--<td style="width: 113px" colspan="4">
                    </td>
                    <td align="right" style="width: 164px">
                    </td>
                    <td style="width: 104px">
                    </td>
                    <td align="right" style="width: 166px">
                    </td>--%>
            <td align="left" class="btnlink" bgcolor="#7daae3" style="height: 17px; width: 113px;"
                colspan="4">
                <!--------------heading start---------------->
                No Issue Dates
                <!--------------heading end--------------->
            </td>
        </tr>
        <tr>
            <td style="width: 73px; height: 22px;">
                <asp:Label ID="lblnoissueday" runat="server" CssClass="TextField"></asp:Label>
            </td>
            <td align="right" style="width: 164px; height: 22px;">
                <asp:DropDownList ID="drpissday" runat="server" CssClass="dropdown">
                </asp:DropDownList>
            </td>
            <td style="width: 104px; height: 22px;">
                <asp:Label ID="lblnoeditiondate" runat="server" CssClass="TextField"></asp:Label>
            </td>
            <td align="right" style="width: 166px; height: 22px;">
                <asp:TextBox onkeypress="return dateenter(event);" ID="txtdate" runat="server" CssClass="btext1"
                    MaxLength="10"></asp:TextBox>
                <img src='Images/cal1.gif' onclick='popUpCalendar(this, Form1.txtdate, "mm/dd/yyyy")'
                    height="14" width="14">
            </td>
        </tr>
        <tr>
            <td style="width: 73px">
            </td>
            <td style="width: 164px">
            </td>
            <td style="width: 104px">
            </td>
            <td style="width: 166px">
            </td>
        </tr>
        <tr>
            <%--</td>--%>
            <td style="width: 73px">
            </td>
            <td align="right" colspan="4">
                <asp:Button ID="btnsubmit" runat="server" CssClass="topbutton" OnClick="btnsubmit_Click">
                </asp:Button><asp:Button ID="btnclear" runat="server" CssClass="topbutton"></asp:Button>
            </td>
        </tr>
        <tr>
            <td style="width: 73px">
                <input id="Hidden1" style="width: 48px; height: 22px" type="hidden" size="2" name="Hidden1"
                    runat="server" />
            </td>
            <td style="width: 164px">
            </td>
            <td style="width: 104px">
            </td>
            <td style="width: 166px">
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4">
                <asp:DataGrid ID="DataGrid1" runat="server" CssClass="dtGrid" AutoGenerateColumns="False"
                    Width="556px" AllowSorting="True" OnItemDataBound="DataGrid1_ItemDataBound1">
                    <HeaderStyle BackColor="#7DAAE3"></HeaderStyle>
                    <Columns>
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" Enabled="true"></asp:CheckBox>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="No_Iss_Code" HeaderText="No_Iss_Code" SortExpression="No_Iss_Code"
                            Visible="False"></asp:BoundColumn>
                        <asp:BoundColumn DataField="No_Iss_day" HeaderText="NO ISSUE DAY">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="no_issue_date" HeaderText="NO EDITION DATE" DataFormatString="{0:d}">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="datecode" HeaderText="datecode" SortExpression="datecode"
                            ReadOnly="True" Visible="False"></asp:BoundColumn>
                    </Columns>
                </asp:DataGrid>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="4">
                <asp:DataGrid ID="DataGrid2" runat="server" CssClass="dtGrid" AutoGenerateColumns="False"
                    Width="515px" OnItemDataBound="DataGrid2_ItemDataBound1">
                    <HeaderStyle BackColor="#7DAAE3"></HeaderStyle>
                    <Columns>
                        <asp:BoundColumn DataField="No_Iss_Code" HeaderText="No_Iss_Code" SortExpression="No_Iss_Code"
                            Visible="False"></asp:BoundColumn>
                        <asp:BoundColumn DataField="NO_ISS_DAY" HeaderText="NO ISSUE DAY">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="no_issue_date" HeaderText="NO EDITION DATE" DataFormatString="{0:d}">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="datecode" HeaderText="datecode" ReadOnly="True" Visible="False">
                        </asp:BoundColumn>
                    </Columns>
                </asp:DataGrid>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="4">
                <%--<asp:button id="btnselect" runat="server" CssClass="topbutton" Text="Select"></asp:button>--%>
                <asp:Button ID="btndelete" runat="server" CssClass="topbutton"></asp:Button>
                <asp:Button ID="btnclose" runat="server" CssClass="button1" />
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="4">
                <table id="Table1" style="width: 560px; height: 15px" cellspacing="0" cellpadding="0"
                    align="center" bgcolor="#7daae3" border="0">
                    <tr>
                        <td align="center" style="height: 17px">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <td>
    </td>
    <td>
    </td>
    <td>
        <input id="hiddennoissuecode" type="hidden" size="1" name="hiddennoissuecode" runat="server" />
        <input id="hdnedition" type="hidden" size="1" name="hiddennoissuecode" runat="server" />
        <input id="hdnnoissuedate" type="hidden" size="1" name="hdnnoissuedate" runat="server" />
        <input id="hiddenshow" type="hidden" size="1" name="hiddennoissuecode" runat="server" />
        <input id="hiddendelsau" type="hidden" size="1" name="hiddennoissuecode" runat="server" />
         <input id="hiddeneditionalias" type="hidden"  runat="server" />
        <input id="hi" type="hidden" size="1" name="hid" runat="server" />
        <input id="hi1" type="hidden" size="1" name="hid" runat="server" />
    </td>
    <td>
        <input id="hiddencompcode" style="width: 48px; height: 22px" type="hidden" size="2"
            name="Hidden1" runat="server" />
        <input style="width: 24px; height: 22px" type="hidden" size="1" name="Hidden2" runat="server"
            id="hiddendateformat" />
    </td>
    <td>
        <input id="hiddeenusername" style="width: 24px; height: 22px" type="hidden" size="1"
            name="Hidden2" runat="server" /><input id="hiddenuserid" style="width: 32px; height: 22px"
                type="hidden" size="1" name="Hidden3" runat="server" /><input id="hiddenissuecode"
                    style="width: 48px; height: 22px" type="hidden" size="2" name="Hidden1" runat="server" /><input
                        id="hiddencode" style="width: 24px; height: 22px" type="hidden" size="1" name="Hidden2"
                        runat="server" />
        <input id="hiddenday" style="width: 24px; height: 22px" type="hidden" size="1" name="Hidden7"
            runat="server" />
        <input id="hiddendate" style="width: 24px; height: 22px" type="hidden" size="1" name="Hidden8"
            runat="server" />
    </td>
    </form>
</body>
</html>
