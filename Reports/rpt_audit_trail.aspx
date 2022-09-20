<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rpt_audit_trail.aspx.cs" Inherits="rpt_audit_trail"  EnableEventValidation="false"%>
<%@ Register TagPrefix="uc1" TagName="Leftbar" Src="~/Leftbar.ascx" %>
<%@ Register TagPrefix="uc2" TagName="Topbar" Src="~/Topbarnew.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Adbooking Audit Trail</title>
    

    <script language="javascript" src="javascript/rpt_audit_trail.js" type="text/javascript"></script>
    <script language="javascript" src="javascript/popupcalender.js"  type="text/javascript"></script>
     <script language="javascript" src="javascript/prototype.js"  type="text/javascript"></script>
    <link href="css/topbar.css" type="text/css" rel="stylesheet"/>
    <link href="css/main_fin.css" type="text/css" rel="stylesheet"/>
    
    <style type="text/css">
        .style1
        {
            width: 217px;
        }
        .style2
        {
            width: 138px;
        }
        .style3
        {
            width: 137px;
        }
        .style4
        {
            width: 44px;
        }
        .style6
        {
            width: 65px;
        }
        .style9
        {
            width: 208px;
        }
        .style10
        {
            width: 290px;
        }
        .style11
        {
            width: 212px;
        }
    </style>
    
</head>
<body style="margin-left:0px;margin-top:0px;"   style="margin:0px 0px;">
    <form id="form1" runat="server">
    <div>
    <%--<div id="divchannel_fpc" style="position: absolute; top: 0px; left: 0px; border: none;display: none; z-index: 1;"><table cellpadding="0" cellspacing="0"><tr><td style="border-bottom:solid 1px gray; border-left:solid 1px gray; border-right:solid 1px gray; border-top:solid 1px gray;"><asp:ListBox ID="lstchannel_fpc" Width="150px" Height="65px" runat="server" CssClass="btextlist"></asp:ListBox></td></tr></table></div>--%>
    <div id="divunit" style="position: absolute; top: 0px; left: 0px; border: none;display: none; z-index: 1;"><table cellpadding="0" cellspacing="0"><tr><td style="border-bottom:solid 1px gray; border-left:solid 1px gray; border-right:solid 1px gray; border-top:solid 1px gray;"><asp:ListBox ID="lstunit" Width="250px" Height="90px" runat="server" CssClass="btextlist" ></asp:ListBox></td></tr></table></div>
    <div>
    <div id="divreport" style="position: absolute; top: 0px; left: 0px; border: none; display: none; z-index: 1;"><table cellpadding="0" cellspacing="0"><tr><td style="border-bottom:solid 1px gray; border-left:solid 1px gray; border-right:solid 1px gray; border-top:solid 1px gray;"><asp:ListBox ID="lstreport" Width="250px" Height="65px" runat="server" CssClass="btextlist"></asp:ListBox></td></tr></table></div>
    <div id="divlogdetail" style="position: absolute; top: 0px; left: 0px; display: none;  z-index: 1;margin-top:30px;">
    <table id="tblgrid2"  border="1">
                <tr>

                <td id="Td1"  runat="server" style="height: 21px" visible ="true"></td>
                </tr>
                </table>
    </div>
    <table>
          <tr>
              <td valign="top">
    <table>

         
        <tr >



        <td style="height: 15px"></td>


        </tr>
   <tr> <td>  

<table border="0" cellpadding="0" cellspacing="0"  width="100%">
<tr>
<td style="width:27px;"></td>
<td style="background-image:url(images/corner-left.jpg);width:11px; background-position:right center; background-repeat:no-repeat; height:20px;"></td>
<td style="width:180px;font-family:Verdana;text-align:right;font-size:10px;background-color:#a0bfeb; height:20px;"><b><center>Adbooking Audit Trail</center></b></td>
<td style="background-image:url(images/corner-right.jpg); background-repeat:no-repeat; height:20px;width:11px"></td>
<td style="width:750px"><table cellpadding="0" cellspacing="0"><tr><td style="background-color:#a0bfeb;width:790px; height:3px;"></td></tr></table></td>
</tr>
</table>  

</td></tr>
   <tr >



        <td style="height: 25px"></td>


        </tr> 
         
         
         
    </table> 

              </td>
         </tr>
    </table>
    </div>
    </div>
    
      <table style="margin-left:70px; margin-top:10px;">
             <tr>
                
                 
                
                 <td>
                         <asp:label id="Reports" runat="server" CssClass="TextField" style="width:auto;margin:5px 10px;"></asp:label>
                 </td>
                 <td style ="width:200px;"><asp:DropDownList ID="DrpLogSelection" runat="server" CssClass="dropdown3" Width="145px"></asp:DropDownList></td>
				
                 
                 
               
                                                    
            </tr>
                                                    
                                                    
    
    </table>
    <table style="margin-left:100px; margin-top:20px;" border='1'>
    <tr id="tr1" style ="display:none;">
            <td class="style3" style="background-color:#a0bfeb;" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Booking Id</td>
              <td><asp:TextBox ID="txtbookid" style="vertical-align:top;" CssClass="btext1" runat="server"></asp:TextBox></td>
    </tr>
    <tr id="tr2" style ="display:none;">
       <td class="style3" style="background-color:#a0bfeb;" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;From</td>       
           
               <td><asp:TextBox ID="txtfrom" style="vertical-align:top;" CssClass="btext1" runat="server"></asp:TextBox> <img src='Images/cal1.gif'  onclick='javascript:return popUpCalendar(this,form1.txtfrom, "dd/mm/yyyy")' onfocus="abc();" alt="" height=14 width=14/></td>
                <td class="style2" style="background-color:#a0bfeb;" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;To</td>
               <td><asp:TextBox ID="txtto" style="vertical-align:top;" CssClass="btext1" runat="server"></asp:TextBox> <img src='Images/cal1.gif'  onclick='javascript:return popUpCalendar(this,form1.txtto, "dd/mm/yyyy")' onfocus="abc();" alt="" height=14 width=14/></td>     
              
            
    </tr>
    </table>
    
    <table style="margin-left:70px; margin-top:30px;" border='1'>
            <tr>
                 <td class="style9" style="background-color:#a0bfeb;" >&nbsp;&nbsp;&nbsp;&nbsp;Select the view fields</td>
                 <td style="width: 53px; height: 26px;">&nbsp;</td>
                 <td style="background-color:#a0bfeb; margin-left :40px " class="style1" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Select the filters   
                 </td>
               </tr>
    </table>
        
    <table>
        
            <tr> <div id="div3" style="position: absolute; top: 0px; left: 0px; border: none;display: none; z-index: 1;">
    <table style="margin-left:70px;" cellpadding="0" cellspacing="0">
        <tr>
           <td class="style6" style="border-bottom:solid 1px gray; border-left:solid 1px gray; border-right:solid 1px gray; border-top:solid 1px gray;">         
              <asp:ListBox ID="ListBox3" Width="214px" Height="253px" runat="server" 
                   CssClass="btextlist" SelectionMode="Multiple" 
                   ></asp:ListBox></td>
                   
                   <td style="width: 53px; height: 26px;">
<asp:Button ID="btnaddn" runat="server" Text=">" Width="25px" /> <br>  <asp:Button ID="btnremove" 
                           runat="server" Text="<" Width="25px" onclick="btnremove_Click" />         
</td>
                   <td>&nbsp;&nbsp;&nbsp;</td>
                 <td class="style4" style="border-bottom:solid 1px gray; border-left:solid 1px gray; border-right:solid 1px gray; border-top:solid 1px gray;">  
              <asp:ListBox ID="ListBox4" Width="214px" Height="253px" runat="server" 
                   CssClass="btextlist" style=" margin-left :0px"></asp:ListBox>                 
           </td>
            <td>&nbsp;&nbsp;&nbsp;</td>
                 <td class="style4" >  
              <asp:ListBox ID="ListBox1" Width="214px" Height="253px" runat="server" 
                   CssClass="btextlist" style=" margin-left :0px; display:none;"></asp:ListBox>                 
           </td>
           <td valign="top">
           <table style="vertical-align:top;">
              <tr>
              <td class="style10">
              <asp:Button id="btnadd" style="vertical-align:top;" Text="SUBMIT" runat="server" 
                      />
              <asp:Button id="btnclear" style="vertical-align:top;" Text="CLEAR" runat="server" />
              </td>
              </tr>
           
              
              </table> 
           </td>
           
        </tr>
        </table>
     </div>
     
     
   </tr>
      <tr>
      <td>
      					 <table id="xlsgrid" style="margin-top:50px; margin-left:50px;" >
     <tr>
       
    <td id="tblgrid1"  runat="server" style="height: 21px" visible ="true"></td>
     </tr>
     </table>
      
      </td>
      
      
      
      </tr>  
   
       
        
        </table>
    
     <input id="hdnlist1" type ="hidden" name="hdnlist" runat ="server" />
    <input id="hdnlist" type ="hidden" name="hdnlist" runat ="server" />
            <input id="hiddendateformat" type="hidden" name="hiddendateformat" runat="server"/>        
            <input id="hiddenuserid" runat="server" type="hidden" name="hiddenuserid"/>&nbsp;
            <input id="hiddenusername" runat="server" type="hidden" name="username"/>
            <input id="hdn_user_right" type="hidden" runat="server" name="hdncompname"/>
            <input id="hiddencompcode" runat="server" type="hidden" name="hiddencompcode"/>
            <input id="hiddenselectedmenu" runat="server" type="hidden" name="hiddenselectedmenu"/>
            <input id="hiddenunit" runat="server" type="hidden" name="hiddenunit"/>
            <input id="hdnuserid" type="hidden" name="hdnuserid" runat="server" />
            <input id="hiddenunitcode" runat="server" type="hidden" name="hiddenunitcode"/>
            <input id="hdnfcpmast" type="hidden" name="hdncompcode" runat="server" />
            <input id="hdnfcpdetail" type="hidden" name="hdncompcode" runat="server" />
            <input id="hdnprgname" type="hidden" name="hdncompcode" runat="server" />
            <input id="deltblfields" type="hidden" name="hdncompcode" runat="server" />
            <input id="hdnmodvalue" type="hidden" name="hdncompcode" runat="server" />
            <input id="hdnChannel" runat="server" type="hidden" name="hiddenunit" />
            <input id="hdnLocation" type="hidden" name="hdncompcode" runat="server" />
            <input id="hdnLanguage" type="hidden" name="hdncompcode" runat="server" />
            <input id="hdnPrgtype" type="hidden" name="hdncompcode" runat="server" />
            <input id="hdnProgram" type="hidden" name="hdncompcode" runat="server" />
            <input id="hdnOriRepeatcode" type="hidden" name="hdncompcode" runat="server" />
            <input id="hdnreport" runat="server" type="hidden" name="hiddenunit" />
            <input id="hdntablename" runat="server" type="hidden" name="hiddenunit" />
            <input id="hndcon" runat="server" type="hidden"  name="hiddenunit" />
        
    
    </form>
</body>
</html>
