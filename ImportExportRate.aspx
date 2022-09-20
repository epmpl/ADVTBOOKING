<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeFile="ImportExportRate.aspx.cs" Inherits="ImportExportRate" %>
<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew_n.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar_n.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Import/Export Rate</title>
        <link href="css/main.css" type="text/css" rel="stylesheet"/>
    <script type="text/javascript"language="javascript" src="javascript/popupcalender.js"></script>
    <script type="text/javascript"language="javascript">
    function check()
    {
         if(document.getElementById('drpadtype').value=="0")
        {
            alert("Please Select Ad Type");
            return false;
        }
        else if(document.getElementById('txtvalidityfrom').value=="")
        {
            alert("Please Enter From Date");
            return false;
        }
        else if(document.getElementById('txttilldate').value=="")
        {
            alert("Please Enter To Date");
            return false;
        }
//         else if(document.getElementById('FileUpload1').value=="")
//        {
//            alert("Please Enter File Name");
//            return false;
//        }
var browser = navigator.appName;
    var packagecode="";
  
        for (var k = 0; k <= document.getElementById("listpackage").length - 1; k++) {
      if (document.getElementById('listpackage').options[k].selected == true)
            {
        var page=  document.getElementById('listpackage').options[k].value;  
              if (browser != "Microsoft Internet Explorer") {
                  var abc = document.getElementById('listpackage').options[k].textContent;
              }
              else {
                  var abc = document.getElementById('listpackage').options[k].innerText;
              }
              
              if(packagecode=="")
              {
              packagecode=page;
              }
              else
              {
                packagecode=packagecode+","+page;
              }
              
              
          
          }
          }
 
          document.getElementById("packagecode1").value=packagecode;
          
          var browser = navigator.appName;
    var Adcategarycode="";
  
        for (var k = 0; k <= document.getElementById("drpcatdest").length - 1; k++) {
      if (document.getElementById('drpcatdest').options[k].selected == true)
            {
        var page=  document.getElementById('drpcatdest').options[k].value;  
              if (browser != "Microsoft Internet Explorer") {
                  var abc = document.getElementById('drpcatdest').options[k].textContent;
              }
              else {
                  var abc = document.getElementById('drpcatdest').options[k].innerText;
              }
              
              if(Adcategarycode=="")
              {
              Adcategarycode=page;
              }
              else
              {
                Adcategarycode=Adcategarycode+","+page;
              }
              
              
          
          }
          }
 
          document.getElementById("hiddenadcategary").value=Adcategarycode;
                  document.getElementById("Hiddenumo").value=document.getElementById("drpdestuom").value;
    }
    function check1()
    {
    if(document.getElementById('FileUpload1').value=="")
        {
            alert("Please Enter File Name");
            return false;
        }
    }
    function check2() {
        //if (document.getElementById('FileUpload1').value == "") {
        document.getElementById('tdall').style.display = "block";
        document.getElementById('td2').style.display = "none";
        
            //return false;
       // }
    }
    function check3() {
        //if (document.getElementById('FileUpload1').value == "") {
        document.getElementById('tdall').style.display = "none";
        document.getElementById('td2').style.display = "block";
        //return false;
        // }
    }
    
    function packagebind() {

    var adtype = "";
    var channel = "";

    adtype = document.getElementById("drpadtype").value;




    var res = ImportExportRate.bindpackage_A_detail(document.getElementById('hiddencompcode').value, adtype, channel);
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
    
     var res = ImportExportRate.advcat(document.getElementById('hiddencompcode').value, adtype);
    var ds = res.value;
    var pkgitem = document.getElementById("drpcatdest");
    pkgitem.multiple = true;
    pkgitem.options.length = 0;
    // pkgitem.options[0]=new Option("-Select-","0");

    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
        //  pkgitem.options.length = 1; 
        for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Adv_Cat_Name, ds.Tables[0].Rows[i].Adv_Cat_Code);
            pkgitem.options.length;
        }

    }
    
       var res = ImportExportRate.binduom(document.getElementById('hiddencompcode').value, adtype);
    var ds = res.value;
    var pkgitem = document.getElementById("drpdestuom");
    
    pkgitem.options.length = 0;
    // pkgitem.options[0]=new Option("-Select-","0");

    if (ds != null && typeof (ds) == "object" && ds.Tables[0].Rows.length > 0) {
        //  pkgitem.options.length = 1; 
        for (var i = 0; i < ds.Tables[0].Rows.length; ++i) {
            pkgitem.options[pkgitem.options.length] = new Option(ds.Tables[0].Rows[i].Uom_Name, ds.Tables[0].Rows[i].Uom_Code);
            pkgitem.options.length;
        }

    }
    
//    document.getElementById("listpackage").focus();
    return false;

}
    </script>
    <style type="text/css">
        .style1
        {
            height: 25px;
        }
    </style>
</head>
<body leftmargin="0" topmargin="0">
    <form id="form1" runat="server">
              <input type="hidden" id="hiddendateformat" runat="server" />
              <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
    <div>
    <table id="OuterTable" width="1000"  border="0" cellpadding="0" cellspacing="0">
				<tr valign="top">
					<td colspan="2"><uc1:topbar id="Topbar1" runat="server" Text="Import/Export Rate"></uc1:topbar></td>
				</tr>
				<tr valign="top">
					<td valign="top"><uc2:leftbar id="Leftbar1" runat="server" ></uc2:leftbar></td>
					<td valign="top">
				</tr>
	</table>
    </div>
    <div>
    <table align="center"      style="border: 4px solid #0066FF; margin-top:50px; caption-side: top;"> 
    <tr>
    <td colspan="4" align="center" bgcolor="#FAC5D8" 
            style="font-family: 'Arial Black'; font-size: x-large; font-weight: bold; color: #3366FF">Export Import Rate Card</td>
    </tr>   
    <tr>
    <td colspan="2"><asp:RadioButton ID="rbsolo" Checked="true" Text="Solo Rate" GroupName="A" runat="server" /><asp:RadioButton Text="Package Rate" GroupName="A" ID="rbpackage" runat="server" /></td>
    <td><asp:Label ID="lblpubcent" runat="server" CssClass="TextField">Center</asp:Label></td>
     <td><asp:DropDownList ID="drppubcenter" runat="server" CssClass="dropdown"></asp:DropDownList></td>
    </tr>
    <tr>
     <td><asp:Label ID="lbladtype" runat="server" CssClass="TextField"> Ad Type<font color="red">*</font></asp:Label></td>
     <td><asp:DropDownList ID="drpadtype" runat="server" CssClass="dropdown" 
             ></asp:DropDownList></td>
     <td><asp:Label id="lblratecode" runat="server" Text="Rate Code" CssClass="TextField"></asp:Label></td>
     <td><asp:ListBox ID="dpratecode" runat="server" SelectionMode="Multiple" CssClass="btextlistqbcnew" Width="145px"></asp:ListBox></td></tr>
     <tr><td ><asp:Label ID="lblvfrm" runat="server" Text="From Date" CssClass="TextField">From Date<font color="red">*</font></asp:Label></td>
       <td ><asp:TextBox ID="txtvalidityfrom" runat="server" CssClass="btext1" Enabled="true" MaxLength="10"    AutoPostBack="True"></asp:TextBox>
     
      <img src='Images/cal1.gif'  onclick='popUpCalendar(this,form1.txtvalidityfrom,"mm/dd/yyyy")' height="14" width="14" />
			</td>
	
       <td><asp:Label ID="lblvalidtill" runat ="server" CssClass="TextField" Align="right" Text="To Date">To Date<font color="red">*</font></asp:Label></td>
       <td> <asp:textbox id="txttilldate" runat="server" CssClass="btext1" Enabled="true" MaxLength="10" AutoPostBack="True"></asp:textbox>
       
    <img src='Images/cal1.gif'  onclick='popUpCalendar(this, form1.txttilldate,"mm/dd/yyyy")' height="14" width="14" >
		
      </td></tr>
      <tr>
        <td >
         <asp:Label ID="lbpackage" runat="server"  CssClass="TextField">Package</asp:Label>
        </td>
        <td colspan="3" rowspan="1"  style=" margin-top:10px;">
        <asp:ListBox ID="listpackage" runat="server" CssClass="btextlistqbcnew" Width="410px"
                  onpaste="return false;" MaxLength="10" SelectionMode="Multiple"></asp:ListBox>
        </td></tr>
        <tr><td class="TextField" align="right">Ad Category</td><td>
                                           <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate> <asp:ListBox ID="drpcatdest" 
                                                CssClass="listbox" runat="server" 
                                                
                                                SelectionMode="Multiple" Width="150px" Height="49px"></asp:ListBox></ContentTemplate></asp:UpdatePanel></td><td class="TextField" align="right">UOM</td><td><asp:UpdatePanel ID="UpdatePanel8" runat="server"><ContentTemplate>
            <asp:DropDownList ID="drpdestuom"  runat="server" CssClass="dropdown" 
               ></asp:DropDownList></ContentTemplate></asp:UpdatePanel></td></tr>
       <tr><td><asp:Label ID="Label1" runat="server" CssClass="TextField"> File Name<font color="red">*</font></asp:Label></td><td colspan=3><asp:FileUpload ID="FileUpload1" runat="server" />
        
       &nbsp;</td></tr>
       <tr>
       <td>
       <asp:RadioButton ID="RadioButton1" Checked="true" Text="EXCEL" GroupName="D" runat="server" /><asp:RadioButton Text="CSV" GroupName="D" ID="RadioButton2" runat="server" />
       </td>
       </tr>
        <tr align="right"><td colspan="2" runat="server" id="td2"  style="display:none"></td><td colspan="2" runat="server" id="tdall"><asp:RadioButton ID="rdall" Checked="true" Text="All" GroupName="B" runat="server" /><asp:RadioButton Text="Main" GroupName="B" ID="rdmain" runat="server" /><asp:RadioButton ID="rdsubedition" Text="Subedition" GroupName="B" runat="server" /><asp:RadioButton Text="Supplement" GroupName="B" ID="rdsupplement" runat="server" /></td><td class="style1" colspan="2" align="center">
          <asp:Button ID="btnupload" CssClass="button1" runat="server" Text="Upload Excel" onclick="btnupload_Click" Width="100px"  /><asp:Button ID="btnimport" CssClass="button1" runat="server" Text="Import" onclick="btnimport_Click"   Width="100px" />
          </td>
        </tr>
      <tr align="right">
          <td class="style1"  colspan='2' align="left"><asp:Label ID="Label2" runat="server" style="color:Red" CssClass="TextField"></asp:Label></td><td class="style1" colspan="2" align="center">
          <asp:Button ID="bnnClear" CssClass="button1" runat="server" Text="Clear"  onclick="bnnClear_Click" Width="100px"  /><asp:Button ID="btnexport" CssClass="button1" runat="server" Text="Export" onclick="btnexport_Click" Width="100px" />
        </tr>
       
        <%--<tr>
        <td colspan="4" align="center"> <asp:Button ID="btnupload" runat="server" Width="200px" Text="Upload Excel"  
                                     CssClass="topbutton" BackColor="LightSteelBlue" onclick="btnupload_Click" ></asp:Button></td>
        </tr>--%>
              </table>
     <table align="center"      style="margin-top:50px; caption-side: top;"> 
     <tr>
        <td align="center"><asp:Label ID="lblerror" runat="server" style="color:Red" CssClass="TextField"></asp:Label></td>
        </tr>
    </table>
    </div>
     <asp:UpdatePanel ID="update1" runat="server"><ContentTemplate>  <input type="hidden" id="packagecode1" runat="server" /></ContentTemplate> </asp:UpdatePanel>
         <asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>  <input type="hidden" id="hiddenadcategary" runat="server" /></ContentTemplate> </asp:UpdatePanel>
      <asp:UpdatePanel ID="UpdatePanel3" runat="server"><ContentTemplate>  <input type="hidden" id="Hiddenumo" runat="server" /></ContentTemplate> </asp:UpdatePanel>
     
    </form>
    
    <input type="hidden" id="hiddencompcode" runat="server" />
        <input type="hidden" id="hiddenuserid" runat="server" />
       

</body>

          
</html>
