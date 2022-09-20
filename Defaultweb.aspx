<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Defaultweb.aspx.cs" Inherits="Defaultweb"  ValidateRequest="false" %>

<%@ register TagPrefix="uc1" TagName="Topbar" Src="~/Topbarnew.ascx"%>
<%@ register TagPrefix="uc2" TagName="Leftbar" Src="~/Leftbar.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Upload</title>
    <script language="javascript" src="javascript/bind.js"></script>
    <link href="css/booking.css" type="text/css" rel="stylesheet" />
  <script language="javascript" src="javascript/webbooking.js" type="text/javascript"></script>

    
    <style type="text/css">
      
       .btextforbook
{
	border: 1px solid #929292;
	background-color: #ffffff;
	font-family: Arial;
	font-size: 13px;
	color: black;
	height:15px;
	width:270px;
}
 
 .TextField1
{
		
	font-family: Trebuchet MS;
	font-size: 13px;
	/*color:#336699;*/
	color:black;
	text-align:right;
	height:11px;
	
	
}
  
        
    </style>
    
      <script type="text/javascript">
          function GetFileName(val) {
              var i = val.lastIndexOf("\\");
              return val.substring(i + 1);
          }



          function settext(val1) {
              var ss=val1;
              var pieces = ss.split("\\");

             // alert(val1)
              var aa = pieces[pieces.length - 1];

            
              
             //document.getElementById('<%= txturl.ClientID %>').value = ss;
              document.getElementById('<%= txt.ClientID %>').value = aa;
          }



          function blankfield123() {
              document.getElementById('FileUpload1').value = "";
              document.getElementById('txt').value = "";
              document.getElementById('txturl').value = "";

              if (document.getElementById('hdntemp').value == "A") {

                  tempexecutewebmaterial();
                  return false;
              }



              if (document.getElementById('hdntemp').value == "B") {

                  executewebmaterial();
                  return false;
              }

            

              return false;
          }




          function executewebmaterial() {

              var res = Defaultweb.execute(document.getElementById('hdnciobookid').value, document.getElementById('hdncompcode').value, document.getElementById('hdnins').value, document.getElementById('hdnfileid').value)
              tempexecutyecallback(res);
            
          }


          function tempexecutewebmaterial() {

          var res=    Defaultweb.tempexecute(document.getElementById('hdnciobookid').value, document.getElementById('hdncompcode').value, document.getElementById('hdnins').value,"")
          tempexecutyecallback(res);
            
          }


          function tempexecutyecallback(res) {
              var dx = res.value;



              if (dx.Tables[0].Rows.length > 0) {

                  document.getElementById('txt').value = dx.Tables[0].Rows[0].pfilename;

                  selval(dx.Tables[0].Rows[0].pfilename);

                  return false;
              }
          }


          var browser = navigator.appName;
         
          function openfile() {
              window.open("webmaterial/" + document.getElementById('lblfilename').innerHTML);
              return false;
          }
          function openfilenew(filename) {
              window.open("webmaterial/" + filename);
              return false;
          }
          function delfilenew(filename) {
              //alert("bhanu");hdncompcode
              if (document.getElementById('hdntemp').value == "B") {
                  Defaultweb.deleteweb(document.getElementById('hdnciobookid').value, document.getElementById('hdncompcode').value, filename)
              }

              if (document.getElementById('hdntemp').value == "A") {
                  Defaultweb.tempdeleteweb(document.getElementById('hdnciobookid').value, document.getElementById('hdncompcode').value, filename)
              }
              
              document.getElementById('hid').value = document.getElementById('lebforattach').innerHTML = document.getElementById('hid').value.replace("<a onclick=openfilenew('" + filename + "')><font style=\"HEIGHT: 25px\" color=\"blue\">" + filename + "</font></a><img onclick=delfilenew('" + filename + "') src=Images/del.jpg>", "");
              if (document.getElementById('hid').value.substring(document.getElementById('hid').value.length - 1, document.getElementById('hid').value.length) == ",")
                  document.getElementById('hid').value = document.getElementById('lebforattach').innerHTML = document.getElementById('hid').value.substring(0, document.getElementById('hid').value.length - 1)
              if (document.getElementById('hid').value.substring(0, 1) == ",")
                  document.getElementById('hid').value = document.getElementById('lebforattach').innerHTML = document.getElementById('hid').value.substring(1, document.getElementById('hid').value.length)

              return false;
          }
          function addlabel(filename) {
              //alert(document.getElementById('lebforattach').innerHTML);
              if (document.getElementById('hid').value == "")
                  document.getElementById('hid').value = document.getElementById('lebforattach').innerHTML = "<a onclick=openfilenew('" + filename + "')><font style=\"HEIGHT: 25px\" color=\"blue\">" + filename + "</font></a><img onclick=delfilenew('" + filename + "') src=Images/del.jpg>";
              else
                  document.getElementById('hid').value = document.getElementById('lebforattach').innerHTML = document.getElementById('hid').value + "," + "<a onclick=openfilenew('" + filename + "')><font style=\"HEIGHT: 25px\" color=\"blue\">" + filename + "</font></a><img onclick=delfilenew('" + filename + "') src=Images/del.jpg>";
              //document.getElementById('lebforattach').title   = filename;
              return false;
          }

          function selval(filename) {
              if (document.getElementById('hid').value == "") {
                  var hidvalue = window.opener.document.getElementById('hidattach1').value;
                  if (window.opener.document.getElementById('hidattach1').value != "") {
                      var splitselect = hidvalue.split(",")
                      for (var t = 0; t < splitselect.length; t++) {
                          if (document.getElementById('hid').value == "")
                              document.getElementById('hid').value = document.getElementById('lebforattach').innerHTML = "<a onclick=openfilenew('" + splitselect[t] + "')><font style=\"HEIGHT: 25px\" color=\"blue\">" + splitselect[t] + "</font></a><img onclick=delfilenew('" + splitselect[t] + "') src=Images/del.jpg>";
                          else
                              document.getElementById('hid').value = document.getElementById('lebforattach').innerHTML = document.getElementById('hid').value + "," + "<a onclick=openfilenew('" + splitselect[t] + "')><font style=\"HEIGHT: 25px\" color=\"blue\">" + splitselect[t] + "</font></a><img onclick=delfilenew('" + splitselect[t] + "') src=Images/del.jpg>";
                      }
                  }
              }

              return false;
          }


          function openfilenew(filename) {
              window.open("webmaterial/" + filename);
              return false;
          }



          function selval(filename) {
              if (document.getElementById('hid').value == "") {
                  var hidvalue = filename.toString();
                  if (filename != "") {
                      var splitselect = hidvalue.split(",")
                      for (var t = 0; t < splitselect.length; t++) {
                          if (document.getElementById('hid').value == "")
                              document.getElementById('hid').value = document.getElementById('lebforattach').innerHTML = "<a onclick=openfilenew('" + splitselect[t] + "')><font style=\"HEIGHT: 25px\" color=\"blue\">" + splitselect[t] + "</font></a><img onclick=delfilenew('" + splitselect[t] + "') src=Images/del.jpg>";
                          else
                              document.getElementById('hid').value = document.getElementById('lebforattach').innerHTML = document.getElementById('hid').value + "," + "<a onclick=openfilenew('" + splitselect[t] + "')><font style=\"HEIGHT: 25px\" color=\"blue\">" + splitselect[t] + "</font></a><img onclick=delfilenew('" + splitselect[t] + "') src=Images/del.jpg>";
                      }
                  }
              }

              return false;
          }
          
          
   </script>
    
    
    
    
    
</head>
<body  onload="javascript:return blankfield123()" style="margin-left:0px;margin-top:-28px;"   >
    <form id="form1" runat="server"> &nbsp;&nbsp;&nbsp;
    
    <table style="width:100%;">
        <tr><td class="style1" align="right">
        <asp:Label ID="lblimage" runat="server" CssClass="TextField1" Text="Image File" align="right"></asp:Label></td>
            <td class="style2"></td>&nbsp;</td><td><asp:FileUpload ID="FileUpload1"  style="width:270px;border: 1px solid #929292;" runat="server"    onchange="settext(this.value);"  />&nbsp;</td></tr>
        <tr><td class="style1" align="right">
        <asp:Label ID="lblname" runat="server" CssClass="TextField1" Text="Name"></asp:Label></td>
            <td class="style2">
                &nbsp;</td><td>
                <asp:TextBox ID="txt" runat="server" CssClass="btextforbook"   Enabled="false" ></asp:TextBox>
            </td></tr>
        <tr><td class="style1" align="right">
        <asp:Label ID="lblimage1" runat="server" CssClass="TextField1" Text="Click-through URL"></asp:Label></td>
            <td class="style2">
                &nbsp;</td><td>
                <asp:TextBox ID="txturl" runat="server" CssClass="btextforbook"   
                    Enabled="true"  AutoPostBack="false"></asp:TextBox>
            </td></tr>
                
                
                
        <tr><td >
   

   
            <asp:Button ID="btnsave1" runat="server"  Text="Save" CssClass="button1"   OnClick="Button1_Click" />&nbsp;
                
  
      
        
            <asp:Button ID="btncancel1" runat="server"  Text="Cancel" CssClass="button1" />
            </td><td class="style2">&nbsp;</td>
            
            
          <td><asp:LinkButton ID="lblfilename" runat="server" style="font-family: verdana;font-size: small"></asp:LinkButton><asp:Label ID="lebforattach" runat="server" style="font-family: verdana;font-size: x-small"></asp:Label>
            
            
            </td></tr>
          </table>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager><br />
        
        <input id="hiddenfilename" runat="server" type="hidden" name="hiddenfilename">&nbsp;
        <input id="hiddencioid" runat="server" type="hidden" name="hiddencioid">
        <input id="hiddenins" runat="server" type="hidden" name="hiddenins">
        <input id="hiddenedition" runat="server" type="hidden" name="hiddenedition">
         <input id="hiddenIP" runat="server" type="hidden" name="hiddenIP">
         <input type="hidden" id="hdnciobookid" runat="server" />
         <input type="hidden" id="hdnins" runat="server" />
         <input type="hidden" id="hdnedit123" runat="server" />
          <input type="hidden" id="hdnfileid" runat="server" />
           <input type="hidden" id="hdnins123" runat="server" />
            <input type="hidden" id="hdncompcode" runat="server" />
             <input type="hidden" id="hdntemp" runat="server" />
         <input id="hid" type="hidden" size="1" name="Hidden2" runat="server" />
    </form>
</body>
</html>
