<%@ Page Language="C#" AutoEventWireup="true" CodeFile="newcombination.aspx.cs" ValidateRequest="false"  Inherits="newcombination" %>
<%@ Register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew.ascx" %>  
<%@ Register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar.ascx" %>
<%@ Register Assembly="YControls" Namespace="YControls" TagPrefix="cc1"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
     <link href="css/main.css" type="text/css" rel="stylesheet"/>
     <link href="style.css" type="text/css" rel="stylesheet"/>
        <script language="javascript" type="text/javascript" src="JavaScript/HGridScript.js"></script>
        <script language="javascript" type="text/javascript" src="javascript/CombinationMaster.js"></script>
		<script language="javascript" type="text/javascript" src="javascript/permission.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    
        <asp:PlaceHolder ID="PlaceHolder1" runat="server">
        <asp:CheckBox ID="CheckBox1" runat="server" />
     
        <YControls:YTripleStateCheckBox Value="0" EnableViewState="true"   Text="My Value" id="YTripleStateCheckBox1" runat="server" />
        
        
        
      </asp:PlaceHolder>
      
        </form>
</body>
</html>
