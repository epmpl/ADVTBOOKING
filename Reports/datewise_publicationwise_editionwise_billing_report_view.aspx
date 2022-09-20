<%@ Page Language="C#" AutoEventWireup="true" CodeFile="datewise_publicationwise_editionwise_billing_report_view.aspx.cs"
    Inherits="datewise_publicationwise_editionwise_billing_report_view" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="css/report.css" rel="stylesheet" type="text/css" />
    <link href="css/main.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" src="javascript/datewise_pubwise_editionwise_billing.js"></script>

    <title>Date Wise Publication Wise Billing Report</title>
</head>
<body>
    <form id="form1" runat="server">
    <div  id="tblgrid" runat="server" visible="true" >
    </div>
    <input id="HDN_dateformat" type="hidden" name="HDN_dateformat" runat="server" />
    <input id="hiddendateformat" type="hidden" name="hiddendateformat" runat="server" />
    <input id="hdncompcode" type="hidden" name="hdncompcode" runat="server" />
    <input id="hdnuserid" type="hidden" name="hdnuserid" runat="server" />
    <input type="hidden" id="hdnunit" runat="server" name="hdnunit" />
    <input id="hdnmainagency11" type="hidden" name="hdnuserid" runat="server" />
    <input id="hdnsubagency11" type="hidden" name="hdnuserid" runat="server" />
    <input id="hdnagname11" type="hidden" name="hdnuserid" runat="server" />
    <input id="hdnfromdate11" type="hidden" name="hdnuserid" runat="server" />
    <input id="hdntodate11" type="hidden" name="hdnuserid" runat="server" />
    <input id="hdnprinting_centercode11" type="hidden" name="hdnuserid" runat="server" />
    <input id="hdnprinting_centername11" type="hidden" name="hdnuserid" runat="server" />
    <input id="hdnbranchcode11" type="hidden" name="hdnuserid" runat="server" />
    <input id="hdnbranchname11" type="hidden" name="hdnuserid" runat="server" />
    <input id="hdncom_out11" type="hidden" name="hdnuserid" runat="server" />
    <input id="hdnrcpt_uptodate11" type="hidden" name="hdnuserid" runat="server" />
    <input id="hdnretype" type="hidden" name="hdnretype" runat="server" />
    <input id="hdnretype11" type="hidden" name="hdnretype" runat="server" />
    <input id="hdnreptype11" type="hidden" name="hdnreptype" runat="server" />
    <input id="hdntype11" type="hidden" name="hdntype11" runat="server" />
    <input id="hdnextra111" type="hidden" name="hdnextra1" runat="server" />
    <input id="hdnextra211" type="hidden" name="hdnextra2" runat="server" />
    <input id="hdnextra311" type="hidden" name="hdnextra2" runat="server" />
    <input id="hdnextra411" type="hidden" name="hdnextra2" runat="server" />
    <input id="hdnextra511" type="hidden" name="hdnextra2" runat="server" />
    <input id="hdnpublication" type="hidden" name="hdnpublication" runat="server" />
    <input id="hdnpubname" type="hidden" name="hdnpubname" runat="server" />
    <input id="hdnadtype" type="hidden" name="hdnadtype" runat="server" />
    <input id="hdnad_type" type="hidden" name="hdnad_type" runat="server" />
    <input id="hdnadcat" type="hidden" name="hdnadcat" runat="server" />
    <input id="hdnad_cat" type="hidden" name="hdnad_cat" runat="server" />
    <input id="hdn_pub_tieup" type="hidden" name="hdn_pub_tieup" runat="server" />
    <input id="hdn_pub_tieup_name" type="hidden" name="hdn_pub_tieup_name" runat="server" />
    </form>
</body>
</html>
