<%@ Page Language="C#" AutoEventWireup="true" CodeFile="fields.aspx.cs" Inherits="classified_fields" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Pop up Classified Category Form</title><link href="../css/main.css" type="text/css" rel="stylesheet"/>
		<%--<link href="css/booking.css" type="text/css" rel="stylesheet"/>--%>
		<link href="../css/report.css" type="text/css" rel="stylesheet"/>
				<script language="javascript" type="text/javascript" src="../javascript/popupcalender.js"></script>
				<script type="text/javascript"  language="javascript" src="../javascript/entertotab.js"></script>
				  <script language="javascript" src="../javascript/billing.js" type="text/javascript"></script>
				         <script language="javascript"  type="text/javascript" src="../javascript/datevalidation.js"></script>
				  <style type="text/css">
    .hiddencol
    {
        display:none;
    }
    .edit_link
    {
    	color:Gray;
    	text-decoration:none;
    }
    .edit_link a
    {
    	color:Gray;
    	text-decoration:none;
    	
    }
    
     .edit_link a:hover
    {
    	text-decoration:underline;
    	color:Red;
    }
   .fileUploadButtonStyle
{
	border-style: solid;
	border-width: 1px;
	color: White;
	background-color: #5282BD;
	font-family: Arial , Verdana, Geneva, Helvetica, sans-serif;
	font-weight: bold;
	border: #5282BD;
}
.blueBorder
{
	border: 2px solid #5282BD;
}
.fileUploadGrid
{
	border: 2px solid #9CBE5A;
}
.fileUploadGrid td
{
	border: 2px solid #9CBE5A;
}
.fileUploadGrid th
{
	border: 0px;
	padding: 6px;
}
.fileUploadGridHeader
{
	color: White;
	background-color: #9CBE5A;
}
.fileUploadGridRow
{
	background-color: #DEE7BD;
}
.whiteBackGround
{
	background-color: White;
}
</style>
<script type="text/javascript" language="javascript">
    //Number Only Validator
    function ClientisNumber(e) {
        var strUserAgent = navigator.userAgent.toLowerCase();
        var isIE = strUserAgent.indexOf("msie") > -1;
        if (isIE) {
            if ((event.keyCode >= 48 && event.keyCode <= 57) || event.keyCode == 0 || event.keyCode == 8 || event.keyCode == 45)
                return true;
            else
            //alert("Enter Numeric Digits");
                return false;
        }
        else {
            if ((event.which >= 48 && event.which <= 57) || event.which == 0 || event.which == 8 || event.which == 45)
                return true;
            else
            //alert("Enter Numeric Digits");
                return false;
        }
    }
    function charValidate() {
        if ((event.keyCode == 32) || (event.keyCode >= 97 && event.keyCode <= 122) || (event.keyCode >= 65 && event.keyCode <= 90)) {
            return true;
        }
        else {
            return false;
        }
    }
</script>
</head>
<body>
    <form id="form1" runat="server">
       <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
      <table border="0" cellspacing="0" cellpadding="0" align="center" style="HEIGHT: 358px">
    <tr>
					<td width="100%" bordercolor="#1" colspan="2"><img src="../images/img_02A.jpg" width="1004" border="0" /></td>
				</tr>
    <tr>
					<td width="100%" bordercolor="#1" colspan="2"><img src="../images/top.jpg" width="1004" border="0" /></td>
				</tr>
							<tr>
								
								<td style="width:200px;"><img src="images/leftbar.jpg" style="WIDTH: 193px; HEIGHT: 483px" height="483" width="193" /></td>
								
								<td valign="top" style="width: 78%">
								
								<div style="width: 800px; margin: 0px auto; padding: 0px; float: left;text-align:left;font-size:16px;padding:10px 10px 10px 112px;">
           <input type="hidden" id="hidid" runat="server" />
           <input type="hidden" id="hidcat" runat="server" />
           <input type="hidden" id="hidscat" runat="server" />
            </div>
            
            <table width="90%">
            <tr><td class="TextField" style="text-align:left;">
            <asp:UpdatePanel ID="panel1" runat="server">
                    <ContentTemplate>
                Location: <asp:DropDownList ID="ddlloc" runat="server" Width="28%" 
                    OnSelectedIndexChanged="ddlloc_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Text="Select State" Value="0"></asp:ListItem>
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="ddlcity" runat="server" Width="28%">
                    <asp:ListItem Text="Select City" Value="0"></asp:ListItem>
                </asp:DropDownList>
                 </ContentTemplate>
                </asp:UpdatePanel>
            </td></tr>
            <tr><td class="TextField" style="text-align:left;">Ad Title: <asp:TextBox ID="txttitle" runat="server" Width="400px"></asp:TextBox></td></tr>
            <tr><td class="TextField" valign="top" style="text-align:left;" id="tblimg" runat="server">
            Upload Image:&nbsp;
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <table cellpadding="4" cellspacing="4">
                        <tr>
                            <td>
                                <asp:Label ID="lblError" CssClass="TextField" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <AjaxUploader:UploadAttachments TempDirectory="UploaderTemp" InsertButtonStyle-CssClass="fileUploadButtonStyle"
                                    InsertText="Browse Image..." runat="server" ID="Attachments1" MultipleFilesUpload="true"
                                    ShowProgressBar="false" ShowCheckBoxes="false" ShowFileIcons="false" ShowProgressInfo="false"
                                    ValidateOption-AllowedFileExtensions="jpeg,jpg,gif,tif,bmp" MaxFilesLimit="3" MaxFilesLimitMsg="Maximum 3 Images can be uploaded!" FlashLoadMode="false"
                                    UploadingMsg="Adding..." HeaderRowStyle-Font-Bold="true" CancelAllMsg="Cancel All">
                                </ajaxuploader:UploadAttachments>
                            </td>
                        </tr>
                        <tr align="center">
                            <td class="blueBorder">
                                <asp:Label CssClass="TextField" ID="lblBrosweMessage" runat="server" Text="You can select maximum 3 pictures to upload!"></asp:Label>
                            </td>
                        </tr>
                        <tr align="center">
                            <td>
                                <asp:Label CssClass="TextField" ID="lblFileTypeMessage" runat="server" Text="Allowed File Type: *.jpeg, *.jpg, *.gif, *.tif, *.bmp"></asp:Label>
                            </td>
                        </tr>                    
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            </td></tr>
         <tr><td align="left"><asp:Repeater ID="frmvw" runat="server" OnItemDataBound="frmvw_ItemDataBound">
                            <ItemTemplate>
                                <div style="clear: both; height: 27px;">
                                    <span style="float: left; width: 10%; text-align: left;margin-bottom:10px;">
                                        <asp:Label CssClass="btext1" ID="lblid" Visible="false" Text='<%#Eval("fld_id")%>' runat="server" />
                                        <asp:Label class="TextField" ID="lblfld" Text='<%#Eval("fld_name")%>' runat="server" />:
                                    </span>
                                    <span style="float: left;margin-bottom:10px;font-family: Trebuchet MS;font-size: 13px;">
                                        <asp:TextBox ID="txtfld" runat="server" />
                                        <asp:CheckBoxList Visible="false" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal" RepeatLayout="Table" RepeatColumns="5" ID="chkList" runat="server">
                                        </asp:CheckBoxList>
                                        <asp:RadioButtonList Visible="false" Font-Bold="true" RepeatDirection="Horizontal" RepeatLayout="Flow" RepeatColumns="4" id="rdoList" runat="server">   
                                        </asp:RadioButtonList>
                                        <asp:DropDownList ID="drpList" Visible="false" runat="server"></asp:DropDownList>
                                    </span>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater></td></tr>
                        <tr><td align="left">								
								<asp:Button Text="Submit" ID="btnsubmit" runat="server" 
                                    onclick="btnsubmit_Click" />                                    
								</td></tr>
                        </table>
								</td></tr>								
								</table>  
    </form>
</body>
</html>
