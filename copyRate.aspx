<%@ Page Language="C#" AutoEventWireup="true" CodeFile="copyRate.aspx.cs" Inherits="copyRate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Copy Rate</title>
    <LINK href="css/booking.css" type="text/css" rel="stylesheet" />
        <script language="javascript" src="javascript/popupcalender.js" type="text/javascript"></script>
        	<script type="text/javascript" language="javascript" src="javascript/datevalidation.js"></script>
        <script language="javascript">
        function msg()
        {
            alert("Rate Copied Successfully");
        }
        function notchar2(event) {

            var browser = navigator.appName;
          
            if (event.shiftKey == true)
                return false;
            if (browser != "Microsoft Internet Explorer") {
                if ((event.which >= 48 && event.which <= 57) || (event.which >= 37 && event.which <= 40) || (event.which == 9) || (event.which == 0) || (event.which == 8) || (event.which == 11) || (event.which == 13)) {

                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                if ((event.keyCode >= 37 && event.keyCode <= 40) || (event.keyCode >= 48 && event.keyCode <= 57) || (event.keyCode == 9) || (event.keyCode == 11) || (event.keyCode == 13) || (event.keyCode == 8)) {

                    return true;
                }
                else {
                    return false;
                }
            }
        }


        function eventcalling(event) {
            if (event.keyCode == 97)
                event.keyCode = 65;
            if (event.keyCode == 98)
                event.keyCode = 66;
            if (event.keyCode == 99)
                event.keyCode = 67;
            if (event.keyCode == 100)
                event.keyCode = 68;
            if (event.keyCode == 101)
                event.keyCode = 69;
            if (event.keyCode == 102)
                event.keyCode = 70;
            if (event.keyCode == 103)
                event.keyCode = 71;
            if (event.keyCode == 104)
                event.keyCode = 72;
            if (event.keyCode == 105)
                event.keyCode = 73;
            if (event.keyCode == 106)
                event.keyCode = 74;
            if (event.keyCode == 107)
                event.keyCode = 75;
            if (event.keyCode == 108)
                event.keyCode = 76;
            if (event.keyCode == 109)
                event.keyCode = 77;
            if (event.keyCode == 110)
                event.keyCode = 78;
            if (event.keyCode == 111)
                event.keyCode = 79;
            if (event.keyCode == 112)
                event.keyCode = 80;
            if (event.keyCode == 113)
                event.keyCode = 81;
            if (event.keyCode == 114)
                event.keyCode = 82;
            if (event.keyCode == 115)
                event.keyCode = 83;
            if (event.keyCode == 116)
                event.keyCode = 84;
            if (event.keyCode == 117)
                event.keyCode = 85;
            if (event.keyCode == 118)
                event.keyCode = 86;
            if (event.keyCode == 119)
                event.keyCode = 87;
            if (event.keyCode == 120)
                event.keyCode = 88;
            if (event.keyCode == 121)
                event.keyCode = 89;
            if (event.keyCode == 122)
                event.keyCode = 90;
        }

        function notss(evt) {
            if (event.shiftKey == true)
                return false;
            var charCode = (evt.which) ? evt.which : event.keyCode
         
            if ((charCode >= 48 && charCode <= 57) || (charCode == 127) || (charCode == 8) || (charCode == 9) || (charCode >= 65 && charCode <= 90) || (charCode >= 97 && charCode <= 122)) {
                return true;
            }
            else {
                return false;
            }
        }

        function check()
        {
   
            if(document.getElementById('txtfromdate').value=="")
            {
      
                alert("Please Enter From Date");
                document.getElementById('txtfromdate').focus();
                return false;
            }
            else if(document.getElementById('txttodate').value=="")
            {
                alert("Please Enter To Date");
                document.getElementById('txttodate').focus();
                return false;
            }
            
            else if(document.getElementById('drpuom').value=="0")
            {
                alert("Please Enter Source UOM");
                document.getElementById('drpuom').focus();
                return false;
            }
             else if(document.getElementById('drpdestuom').value=="0")
            {
                alert("Please Enter Destination UOM");
                document.getElementById('drpdestuom').focus();
                return false;
            }
            else if(document.getElementById('drpcat').value=="0")
            {
                alert("Please Enter Source Ad Category");
                document.getElementById('drpuom').focus();
                return false;
            }
             else if(document.getElementById('drpcatdest').value=="0")
            {
                alert("Please Enter Destination Ad Category");
                document.getElementById('drpdestuom').focus();
                return false;
            }
            else if (document.getElementById('drpcolor').value == "0") {
            alert("Please Enter Source Color");
                document.getElementById('drpcolor').focus();
                return false;
            }
            else if (document.getElementById('drpcolorcop').value == "0") {
            alert("Please Enter Destination Color");
                document.getElementById('drpcolorcop').focus();
                return false;
            }
            else if (document.getElementById('drpratecode').value == "0") {
            alert("Please Enter Rate Code");
                document.getElementById('drpratecode').focus();
                return false;
            }
              else if (document.getElementById('txtRatecode').value == "0") {
            alert("Please Enter Destination Rate Code");
                document.getElementById('drpratecode').focus();
                return false;
            }
            
            
             else if(document.getElementById('listpackage').value=="" || document.getElementById('listpackage').value=="0")
            {
                alert("Please Select Packages from Source");
                document.getElementById('drpratecode').focus();
                return false;
            }
            
            
             var fromdate=document.getElementById('txtfromdate').value;
		    var todate=document.getElementById('txttodate').value;
		    var fdate=new Date(fromdate);
		    var tdate=new Date(todate);
		    if(fdate>tdate)
		        {
		        alert("From Date Should Be Less Than To Date");
		        //document.getElementById('txtfromdate').value="";
		        document.getElementById('txtfromdate').focus();
		        return false;
		        }
        }
        
         function packagebind() {

    var adtype = "";
    var channel = "";

    adtype = document.getElementById("drpadtype").value;




    var res = copyRate.bindpackage_A_detail(document.getElementById('hiddencompcode').value, adtype, channel);
    var ds = res.value;
    var pkgitem = document.getElementById("listpackage");
    pkgitem.multiple = true;
    pkgitem.options.length = 0;
    // pkgitem.options[0]=new Option("-Select-","0");

    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
        //  pkgitem.options.length = 1; 
        for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Package_Name, ds.Tables[0].Rows[i].Combin_Code);
            pkgitem.options.length;
        }

    }
    


}
        </script>
</head>
<body onkeypress="eventcalling(event);">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div>
   <table cellpadding=0   style="padding-bottom:50px" cellspacing=0 align="center"><tr><td align="Center" style="font-family:Century Gothic;font-weight:bold;font-size:small" >Copy Rate From One Category To Another Category</td></tr></table>
   <table border="1" width="80%" align="center"><tr><td>
    <table width="80%" align="center" cellpadding="0" cellspacing="0" border="0">
    
    <tr>
    <td class="printTextField"><b>Source</b></td>
   
    <td class="printTextField"><b>Destination</b></td>
    
    </tr>
    
    <tr><td><table>
    <tr><td class="TextField" id ="from1" align="right" runat="server"></td><td><asp:TextBox ID="txtfromdate" CssClass="btextforbook" runat="server"></asp:TextBox><img
                                                        src='Images/cal1.gif' id="Img2" onclick='popUpCalendar(this, form1.txtfromdate, "mm/dd/yyyy")'
                                                         height="11" width="14" /></td></tr><tr><td class="TextField" id="to1" runat="server" align="right"></td><td><asp:TextBox ID="txttodate" CssClass="btextforbook" runat="server"></asp:TextBox><img
                                                        src='Images/cal1.gif' id="Img1" onclick='popUpCalendar(this, form1.txttodate, "mm/dd/yyyy")'
                                                         height="11" width="14" /></td></tr>
    <tr><td class="TextField" align="right">Ad Type</td><td><asp:UpdatePanel ID="UpdatePanel6" runat="server"><ContentTemplate><asp:DropDownList ID="drpadtype" CssClass="dropdownforbook" runat="server" AutoPostBack="true"  OnSelectedIndexChanged="drpadtype_SelectedIndexChanged"></asp:DropDownList></ContentTemplate></asp:UpdatePanel></td></tr>                                                         
    <tr><td class="TextField" align="right">Ad Category</td><td><asp:UpdatePanel ID="up1" runat="server"><ContentTemplate><asp:DropDownList ID="drpcat" AutoPostBack="true" Enabled="false" CssClass="dropdownforbook" runat="server" OnSelectedIndexChanged="drpcat_SelectedIndexChanged"></asp:DropDownList></ContentTemplate></asp:UpdatePanel></td></tr>
    <tr><td class="TextField" align="right">Ad SubCategory</td><td><asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate><asp:DropDownList ID="drpsubcat" Enabled="false" AutoPostBack="true" runat="server" CssClass="dropdownforbook" OnSelectedIndexChanged="drpsubcat_SelectedIndexChanged"></asp:DropDownList></ContentTemplate></asp:UpdatePanel></td></tr>
    <tr><td class="TextField" align="right">Ad Sub Sub Category</td><td><asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate><asp:DropDownList ID="drpsubsubcat" Enabled="false" runat="server" CssClass="dropdownforbook"></asp:DropDownList></ContentTemplate></asp:UpdatePanel></td></tr>
        <tr><td class="TextField" align="right">UOM</td><td><asp:UpdatePanel ID="UpdatePanel7" runat="server"><ContentTemplate><asp:DropDownList ID="drpuom" runat="server"  CssClass="dropdownforbook"></asp:DropDownList></ContentTemplate></asp:UpdatePanel></td></tr>
          <tr><td class="TextField" align="right">Color</td><td><asp:UpdatePanel ID="UpdatePanel9" runat="server"><ContentTemplate><asp:DropDownList ID="drpcolor" runat="server"  CssClass="dropdownforbook"></asp:DropDownList></ContentTemplate></asp:UpdatePanel></td></tr>
    <tr><td class="TextField" align="right">Rate Code</td><td><asp:UpdatePanel ID="UpdatePanel11" runat="server"><ContentTemplate><asp:DropDownList ID="drpratecode" runat="server"  CssClass="dropdownforbook"></asp:DropDownList></ContentTemplate></asp:UpdatePanel></td></tr>
       <tr>
        <td >
         <asp:Label ID="lbpackage" runat="server"  CssClass="TextField">Package</asp:Label>
        </td>
        <td colspan="3" rowspan="1"  style=" margin-top:10px;">
      <asp:UpdatePanel ID="UpdatePanel13" runat="server"><ContentTemplate>  <asp:ListBox ID="listpackage" runat="server" CssClass="btextlistqbcnew" Width="167px"
                  onpaste="return false;" MaxLength="10" AutoPostBack="true"></asp:ListBox></ContentTemplate></asp:UpdatePanel>
        </td></tr>
    </table></td>
    
    <td>
    <table><tr><td class="TextField" align="right">Ad Category</td><td><asp:UpdatePanel ID="UpdatePanel3" runat="server"><ContentTemplate>
                                            <asp:ListBox ID="drpcatdest" AutoPostBack="true" Enabled="false" 
                                                CssClass="listbox" runat="server" 
                                                OnSelectedIndexChanged="drpcatdest_SelectedIndexChanged" 
                                                SelectionMode="Multiple" Width="119px"></asp:ListBox></ContentTemplate></asp:UpdatePanel></td></tr>
    <tr><td class="TextField" align="right">Ad SubCategory</td><td><asp:UpdatePanel ID="UpdatePanel4" runat="server"><ContentTemplate><asp:DropDownList ID="drpsubcatdest" Enabled="false" AutoPostBack="true" CssClass="dropdownforbook" runat="server" OnSelectedIndexChanged="drpsubcatdest_SelectedIndexChanged"></asp:DropDownList></ContentTemplate></asp:UpdatePanel></td></tr>
    <tr><td class="TextField" align="right">Ad Sub Sub Category</td><td><asp:UpdatePanel ID="UpdatePanel5" runat="server"><ContentTemplate><asp:DropDownList ID="drpsubsubcatdest" Enabled="false" CssClass="dropdownforbook" runat="server"></asp:DropDownList></ContentTemplate></asp:UpdatePanel></td></tr>
    <tr><td class="TextField" align="right">UOM</td><td><asp:UpdatePanel ID="UpdatePanel8" runat="server"><ContentTemplate><asp:DropDownList ID="drpdestuom"  runat="server" CssClass="dropdownforbook"></asp:DropDownList></ContentTemplate></asp:UpdatePanel></td></tr>
<tr><td class="TextField" align="right">Color</td><td><asp:UpdatePanel ID="UpdatePanel10" runat="server"><ContentTemplate><asp:DropDownList ID="drpcolorcop" runat="server"  CssClass="dropdownforbook"></asp:DropDownList></ContentTemplate></asp:UpdatePanel></td></tr>
<tr><td class="TextField" align="right">Percentage</td><td><asp:TextBox ID="txtpercentage"  CssClass="btextforbook" MaxLength="3" runat="server" onkeydown="javascript:return notchar2(event);" ></asp:TextBox></td></tr>
<tr><td class="TextField" align="right">Rate Code</td><td>
<asp:UpdatePanel ID="UpdatePanel14" runat="server"><ContentTemplate>
<asp:DropDownList ID="txtRatecode" runat="server"  CssClass="dropdownforbook"></asp:DropDownList>
</ContentTemplate></asp:UpdatePanel>

</td></tr>
   <tr>
        <td >
         <asp:Label ID="Label1" runat="server"  CssClass="TextField" Visible="false">Package</asp:Label>
        </td>
        <td colspan="3" rowspan="1"  style=" margin-top:10px;"><asp:UpdatePanel ID="UpdatePanel12" runat="server"><ContentTemplate>
        <asp:ListBox ID="ListBox1" runat="server" CssClass="btextlistqbcnew" Width="158px" Visible="false"
                  onpaste="return false;" MaxLength="10" SelectionMode="Multiple" AutoPostBack="true"></asp:ListBox></ContentTemplate></asp:UpdatePanel>
        </td></tr>
<tr><td></td><td></td></tr>    
    </table>
    </td>
    </tr>
    <tr><td></td><td align="center"><asp:UpdatePanel ID="up2" runat="server">
    <ContentTemplate><asp:Button ID="btngo"  runat="server" Text="Copy Rate" OnClick="btngo_Click" /></ContentTemplate>
    </asp:UpdatePanel></td></tr>
    </table>
    </td></tr></table>
    <input type="hidden" id="hiddendateformat" value="mm/dd/yyyy" runat="server" />
    </div>
    </form>
</body>
</html>
